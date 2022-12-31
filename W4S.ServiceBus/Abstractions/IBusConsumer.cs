using W4S.ServiceBus.Events;

namespace W4S.ServiceBus.Abstractions
{
    public interface IBusConsumer : IDisposable
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void Start();
    }
}
