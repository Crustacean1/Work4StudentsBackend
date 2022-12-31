namespace ServiceBus.Abstractions
{
    public interface IServiceBusFactory
    {
        public string ServiceName { get; }

        public IBusProducer CreateProducer();

        public IBusConsumer CreateEventConsumer(string topic);

        public IBusConsumer CreateRequestConsumer(string topic);
    }
}
