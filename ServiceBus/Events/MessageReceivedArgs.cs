using RabbitMQ.Client.Events;

namespace ServiceBus.Events
{
    public class MessageReceivedEventArgs : EventArgs
    {
        private readonly BasicDeliverEventArgs args;

        public MessageReceivedEventArgs(BasicDeliverEventArgs args)
        {
            this.args = args;
        }

        public string Topic => args.RoutingKey;
        public ReadOnlySpan<byte> RequestBody => args.Body.Span;
        public string ReplyTopic => args.BasicProperties.ReplyTo;
        public Guid RequestId => Guid.Parse(args.BasicProperties.CorrelationId);
    }
}
