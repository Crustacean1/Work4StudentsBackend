using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceBus.Rabbit;

namespace ServiceBus.Package
{
    public sealed class ServiceBusReceiverContainer : IHostedService, IDisposable
    {
        private readonly IServiceProvider provider;
        private readonly ILogger<ServiceBusReceiverContainer> logger;
        private readonly HandlerContainer handlerContainer;
        private readonly ServiceBusConnection serviceBusConnection;

        private bool disposed;
        private readonly List<IServiceBusReceiver> receivers;

        public ServiceBusReceiverContainer(
            IServiceProvider provider,
            ILogger<ServiceBusReceiverContainer> logger,
            HandlerContainer handlerContainer,
            ServiceBusConnection serviceBusConnection)
        {
            this.provider = provider;
            this.logger = logger;
            this.handlerContainer = handlerContainer;
            this.serviceBusConnection = serviceBusConnection;
            receivers = new List<IServiceBusReceiver>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var handler in handlerContainer.Handlers)
            {
                logger.LogInformation("Creating receiver for topic: {Topic}", handler.HandlerName);
                var receiver = new ServiceBusReceiver(provider, logger, handler.HandlerType, serviceBusConnection, handler.HandlerName);
                receivers.Add(receiver);
            }

            var connectionTasks = receivers.Select(r => Task.Run(r.Start));
            await Task.WhenAll(connectionTasks);
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
    }
}
