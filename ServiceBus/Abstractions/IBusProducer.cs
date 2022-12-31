namespace ServiceBus.Abstractions
{
    public interface IBusProducer
    {
        public void Publish(string topic, byte[] messageBody);

        public void Send(string topic, string replyTopic, byte[] messageBody, Guid requestId);

        public void Reply(string topic, byte[] messageBody, Guid requestId);

        public void Start();
    }
}
