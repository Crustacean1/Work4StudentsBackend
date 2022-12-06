using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceBus.Rabbit;

namespace ServiceBus
{
    public sealed class ServiceBusReceiverContainer : IHostedService, IDisposable
    {
        private readonly IServiceProvider provider;
        private readonly ILogger<ServiceBusReceiverContainer> logger;
        private readonly HandlerContainer handlerContainer;
        private readonly ServiceBusConnection serviceBusConnection;

        private bool disposed;
        private List<IServiceBusReceiver> receivers;

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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var handler in handlerContainer.Handlers)
            {
                receivers.Add(new ServiceBusReceiver(provider, logger, handler.HandlerType, serviceBusConnection, handler.HandlerName));
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
    }
}
