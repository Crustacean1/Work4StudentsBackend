namespace W4S.ServiceBus.Abstractions
{
    public interface IClient
    {
        public void SendEvent<TEvent>(string topic, TEvent busEvent) where TEvent : class;
        public Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request) where TResponse : class where TRequest : class;
        public Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request, CancellationToken cancellationToken) where TResponse : class where TRequest : class;
    }
}
