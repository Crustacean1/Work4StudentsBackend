namespace ServiceBus.Rabbit
{
    public interface IServiceBusSender
    {
        public void SendEvent<TEvent>(string topic, TEvent busEvent) where TEvent : class;

        public Task<TResult> SendRequest<TRequest, TResult>(string topic, TRequest request) where TResult : class, new();
    }
}
