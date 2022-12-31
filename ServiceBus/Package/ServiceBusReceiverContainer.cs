using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;
using ServiceBus.Attributes;
using System.Reflection;

namespace ServiceBus.Package
{
    public sealed class ServiceBusReceiverContainer : IHostedService, IDisposable
    {
        private readonly IServiceProvider provider;
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<ServiceBusReceiverContainer> logger;
        private readonly IServiceBusFactory serviceBusFactory;

        private bool disposed;
        private readonly List<ExecutorBase> handlers = new();

        public ServiceBusReceiverContainer(
            IServiceProvider provider,
            ILogger<ServiceBusReceiverContainer> logger,
            ILoggerFactory loggerFactory,
            IServiceBusFactory serviceBusFactory)
        {
            this.provider = provider;
            this.logger = logger;
            this.loggerFactory = loggerFactory;
            this.serviceBusFactory = serviceBusFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var (requestHandlers, eventHandlers) = FindAllHandlers();

            foreach (var requestHandler in requestHandlers)
            {
                var handler = new RequestExecutor(provider,
                                                   requestHandler.Value,
                                                   serviceBusFactory.CreateRequestConsumer(requestHandler.Key),
                                                   serviceBusFactory.CreateProducer(),
                                                   loggerFactory.CreateLogger<RequestExecutor>());
                handlers.Add(handler);
                handler.Start();
            }

            foreach (var eventHandler in eventHandlers)
            {
                var handler = new EventExecutor(provider,
                                                   eventHandler.Value,
                                                   serviceBusFactory.CreateRequestConsumer(eventHandler.Key),
                                                   loggerFactory.CreateLogger<EventExecutor>());
                handlers.Add(handler);
                handler.Start();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                /* TODO: dispose of all executors here */
            }
        }

        private (IDictionary<string, MethodInfo> requestHandlers, IDictionary<string, MethodInfo> eventHandlers) FindAllHandlers()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            if (currentAssembly is null) { throw new InvalidOperationException("Can it be, perchance, thee hath not runneth this wrapper as executable?"); }

            var eventHandlers = new Dictionary<string, MethodInfo>();
            var requestHandlers = new Dictionary<string, MethodInfo>();

            foreach (var type in currentAssembly.GetTypes())
            {
                if (Attribute.GetCustomAttributes(type, typeof(BusServiceAttribute)).SingleOrDefault() is BusServiceAttribute classAttribute)
                {
                    var methods = type.GetMethods();

                    foreach (var method in methods)
                    {
                        if (method.GetParameters().Count() != 1) { continue; }

                        if (method.GetCustomAttribute<BusRequestHandlerAttribute>() is BusRequestHandlerAttribute requestHandler)
                        {
                            requestHandlers.Add($"{classAttribute.Name}.{requestHandler.Name}", method);
                        }
                        else if (method.GetCustomAttribute<BusEventHandlerAttribute>() is BusEventHandlerAttribute eventHandler)
                        {
                            eventHandlers.Add($"{classAttribute.Name}.{eventHandler.Name}", method);
                        }
                    }
                }
            }
            return (requestHandlers, eventHandlers);
        }
    }
}
