using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;

namespace ServiceBus.Rabbit
{
    public class ServiceBusFactory : IServiceBusFactory
    {
        private readonly ServiceBusConnection connection;
        private readonly ILoggerFactory loggerFactory;

        private IBusClient? busClient;

        public ServiceBusFactory(ServiceBusConnection connection, ILoggerFactory loggerFactory)
        {
            this.connection = connection;
            this.loggerFactory = loggerFactory;
        }

        public IBusClient GetClient()
        {
            busClient ??= new BusClient(connection, loggerFactory.CreateLogger<BusClient>()).Start();
            return busClient;
        }

        public IBusServer CreateServer()
        {
            return new BusServer(connection, loggerFactory.CreateLogger<BusServer>());
        }
    }
}
