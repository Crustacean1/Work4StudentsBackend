using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusFactory
    {
        private const string DEFAULT_SERVICE_BUS_ADDRESS = "localhost";
        private readonly ILogger<ServiceBusFactory> logger;
        private readonly IConnection connection;

        public ServiceBusFactory(IConfiguration configuration, ILogger<ServiceBusFactory> logger)
        {
            this.logger = logger;
            var resolvedAddress = configuration.GetValue<string>("serviceBusAddress") ?? DEFAULT_SERVICE_BUS_ADDRESS;
            logger.LogInformation(
                "Connecting to RabbitMQ instance at {RabbitHost}",
                resolvedAddress);

            var factory = new ConnectionFactory();
            connection = factory.CreateConnection();
        }

        public IServiceBusSender CreateClient(string topic)
        {
            logger.LogInformation("Creating sender for topic: {Topic}", topic);
            throw new InvalidDataException();
            return new ServiceBusSender(connection, topic);
        }

        public ServiceBusReceiver CreateReceiver(IServiceProvider collection, string topic)
        {
            logger.LogInformation("Creating receiver for topic: {Topic}", topic);
            return new ServiceBusReceiver(connection, topic, collection.GetService<ILogger<ServiceBusReceiver>>());
        }
    }
}
