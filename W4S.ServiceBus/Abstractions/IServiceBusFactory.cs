namespace W4S.ServiceBus.Abstractions
{
    public interface IServiceBusFactory
    {
        public string ServiceName { get; }

        public IBusProducer CreateProducer();

        public IBusConsumer CreateMulticastConsumer(string topic);

        public IBusConsumer CreateUnicastConsumer(string topic);
    }
}
