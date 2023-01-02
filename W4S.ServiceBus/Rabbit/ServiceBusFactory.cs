using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using W4S.ServiceBus.Abstractions;

namespace W4S.ServiceBus.Rabbit
{
    public class ServiceBusFactory : IServiceBusFactory
    {
        private readonly ServiceBusConnection connection;
        private readonly ILoggerFactory loggerFactory;

        public string ServiceName => connection.ServiceName;

        public ServiceBusFactory(ServiceBusConnection connection, ILoggerFactory loggerFactory)
        {
            this.connection = connection;
            this.loggerFactory = loggerFactory;
        }

        public IBusProducer CreateProducer()
        {
            return new BusProducer(connection,
                                   DeclareEventExchange,
                                   loggerFactory.CreateLogger<BusProducer>());
        }

        public IBusConsumer CreateMulticastConsumer(string topic)
        {
            return new BusConsumer(connection,
                                   DeclareEventExchange,
                                   $"{connection.ServiceName}.{topic}",
                                   topic,
                                   ServiceBusConnection.EventExchange,
                                   loggerFactory.CreateLogger<BusConsumer>());
        }

        public IBusConsumer CreateUnicastConsumer(string topic)
        {
            return new BusConsumer(connection,
                                   DeclareRequestExchange,
                                   $"{connection.ServiceName}.{topic}",
                                   topic,
                                   ServiceBusConnection.RequestExchange,
                                   loggerFactory.CreateLogger<BusConsumer>());
        }

        private static void DeclareEventExchange(IModel channel)
        {
            channel.ExchangeDeclare(exchange: ServiceBusConnection.EventExchange, type: ExchangeType.Topic);
        }

        private static void DeclareRequestExchange(IModel channel)
        {
            channel.ExchangeDeclare(exchange: ServiceBusConnection.RequestExchange, type: ExchangeType.Direct);
        }
    }
}
