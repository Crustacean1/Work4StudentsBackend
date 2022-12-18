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
        private readonly List<HandlerExecutor> receivers;

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
            receivers = new List<HandlerExecutor>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var handlers = FindAllHandlers();
            foreach (var handlerType in handlers)
            {
                var receiver = new HandlerExecutor(provider, loggerFactory.CreateLogger<HandlerExecutor>(), handlerType, serviceBusFactory);
                receivers.Add(receiver);
                receiver.Start();
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
                foreach (var receiver in receivers)
                {
                    receiver?.Dispose();
                }
            }
        }

        public IEnumerable<Type> FindAllHandlers()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            if (currentAssembly is null) { throw new InvalidOperationException("Can it be, perchance, thee hath not runneth this wrapper as executable?"); }
            var handlerTypes = new List<Type>();
            foreach (var type in currentAssembly.GetTypes())
            {
                if (Attribute.GetCustomAttributes(type, typeof(ServiceBusHandlerAttribute)).SingleOrDefault() is not null)
                {
                    handlerTypes.Add(type);
                }
            }
            return handlerTypes;
        }
    }
}
