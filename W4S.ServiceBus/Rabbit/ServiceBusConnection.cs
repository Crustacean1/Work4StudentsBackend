using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace W4S.ServiceBus.Rabbit
{
    public sealed class ServiceBusConnection : IDisposable
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBusConnection> logger;

        private IConnection? connection;
        private readonly string brokerAddress;
        private bool disposed;

        public IConnection Connection
        {
            get
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("ServiceBus is already disposed");
                }
                logger.LogInformation("Connecting to host: {HostName}", brokerAddress);
                return connection ??= new ConnectionFactory() { HostName = brokerAddress }.CreateConnection();
            }
        }

        public static string EventExchange => "ServiceBus.Event";
        public static string RequestExchange => "ServiceBus.Request";
        public string ServiceName { get; }

        public ServiceBusConnection(ILogger<ServiceBusConnection> logger)
        {
            this.logger = logger;
            brokerAddress = Environment.GetEnvironmentVariable("BUS_BROKER_ADDRESS") ?? DEFAULT_SERVICE_BUS_ADDRESS;
            ServiceName = Environment.GetEnvironmentVariable("SERVICE_NAME")
                ?? throw new InvalidDataException("Environment variable 'SERVICE_NAME' is not specified!");
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
