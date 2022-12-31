using ServiceBus.Events;

namespace ServiceBus.Abstractions
{
    public interface IBusConsumer : IDisposable
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void Start();
    }
}
