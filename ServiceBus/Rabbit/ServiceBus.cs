using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.Rabbit
{
    public sealed class ServiceBus : IDisposable
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBus> logger;

        private IConnection? connection;
        private string serviceBusAddress;
        private bool disposed;

        private IModel? channel;

        public IModel Channel
        {
            get
            {
                if (channel is null)
                {
                    logger.LogInformation(
                        "Connecting to RabbitMQ instance at {RabbitHost}",
                        serviceBusAddress);

                    var factory = new ConnectionFactory();
                    connection = factory.CreateConnection();
                    channel = connection.CreateModel();
                }
                return channel;
            }
        }

        public ServiceBus(IConfiguration configuration, ILogger<ServiceBus> logger)
        {
            this.logger = logger;
            serviceBusAddress = configuration.GetValue<string>("serviceBusAddress") ?? DEFAULT_SERVICE_BUS_ADDRESS;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                channel?.Dispose();
                channel = null;
                connection?.Dispose();
                connection = null;
            }
        }
    }
}
