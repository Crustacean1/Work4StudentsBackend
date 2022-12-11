using ServiceBus.Events;

namespace ServiceBus.Abstractions
{
    public interface IBusServer : IDisposable
    {
        public event EventHandler<RequestReceivedArgs> RequestReceived;
        public event EventHandler<EventReceivedArgs> EventReceived;

        public void Start(string topic);
    }
}
