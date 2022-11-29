using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusClientFactory
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBusClientFactory> logger;
        private IConnection connection;

        private static Action<ILogger, string, Exception> startedConnection = LoggerMessage.Define(LogLevel.Information, new EventId(2, nameof(StartedConnection)), "Connecting to: {host}");

        public ServiceBusClientFactory(IConfiguration configuration, ILogger<ServiceBusClientFactory> logger)
        {
            this.logger = logger;
            var resolvedAddress = configuration.GetValue<string>("serviceBusAddress") ?? DEFAULT_SERVICE_BUS_ADDRESS;
            logger.LogInformation(
                "Connecting to RabbitMQ instance at {rabbitHost}",
                resolvedAddress);

            var factory = new ConnectionFactory();
            connection = factory.CreateConnection();
        }

        public IServiceBusClient CreateClient(string topic)
        {
            return new ServiceBusClient(connection, topic);
        }

        private void StartedConnection(this ILogger logger, string host)
        {
            startedConnection(logger, host, null);
        }
    }
}
