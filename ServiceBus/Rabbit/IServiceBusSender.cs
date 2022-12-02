namespace ServiceBus.Rabbit
{
    public interface IServiceBusSender
    {
        public void SendEvent<TEvent>(TEvent busEvent) where TEvent : class;

        public Task<TResult> SendRequest<TRequest, TResult>(TRequest request) where TResult : class, new();
    }
}