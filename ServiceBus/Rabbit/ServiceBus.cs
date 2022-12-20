using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace ServiceBus.Rabbit
{
    public sealed class ServiceBusConnection : IDisposable
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBusConnection> logger;

        private IConnection? connection;
        private readonly string serviceBusAddress;
        private bool disposed;

        public IConnection Connection
        {
            get
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("ServiceBus is already disposed");
                }
                logger.LogInformation("Connecting to host: {HostName}", serviceBusAddress);
                return connection ??= new ConnectionFactory() { HostName = serviceBusAddress }.CreateConnection();
            }
        }

        public static string DefaultExchange => "events";
        public static string DefaultExchangeType => ExchangeType.Topic;

        public ServiceBusConnection(ILogger<ServiceBusConnection> logger)
        {
            this.logger = logger;
            serviceBusAddress = Environment.GetEnvironmentVariable("SERVICE_BUS_ADDRESS") ?? DEFAULT_SERVICE_BUS_ADDRESS;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                connection?.Dispose();
                connection = null;
            }
        }
    }
}
