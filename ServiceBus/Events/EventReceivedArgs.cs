using RabbitMQ.Client.Events;

namespace ServiceBus.Events
{
    public class EventReceivedEventArgs : EventArgs
    {
        private readonly BasicDeliverEventArgs args;

        public EventReceivedEventArgs(BasicDeliverEventArgs args)
        {
            this.args = args;
        }

        public string Topic => args.RoutingKey;
        public ReadOnlySpan<byte> EventBody => args.Body.Span;
    }
}
