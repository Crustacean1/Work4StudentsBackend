using ServiceBus.Events;

namespace ServiceBus.Abstractions
{
    public interface IBusClient
    {
        public event EventHandler<ResponseReceivedArgs> ResponseReceived;

        public void SendEvent(string topic, string eventBody);
        public void SendRequest(string topic, Guid requestId, string requestBody);
        public void SendResponse(string topic, Guid requestId, string responseBody);
    }
}
