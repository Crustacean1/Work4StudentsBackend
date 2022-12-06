using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.Rabbit
{
    public sealed class ServiceBusConnection : IDisposable
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBusConnection> logger;

        private IConnection? connection;
        private string serviceBusAddress;
        private bool disposed;

        public IConnection Connection
        {
            get
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("ServiceBus is already disposed");
                }
                return connection ?? new ConnectionFactory().CreateConnection();
            }
        }

        public static string DefaultExchange => "events";

        public ServiceBusConnection(IConfiguration configuration, ILogger<ServiceBusConnection> logger)
        {
            this.logger = logger;
            serviceBusAddress = configuration.GetValue<string>("serviceBusAddress") ?? DEFAULT_SERVICE_BUS_ADDRESS;
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
