namespace PostingService.Console.ServiceBus
{
    public interface IServiceBusClient
    {
        public void SendEvent<TEvent>(TEvent busEvent);

        public Task<TResult> SendRequest<TRequest, TResult>(TRequest request) where TResult : new();
    }
}
