namespace ServiceBus.Abstractions
{
    public interface IServiceBusFactory
    {
        public IBusClient GetClient();
        public IBusServer CreateServer();
    }
}
