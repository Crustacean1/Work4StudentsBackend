using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;

namespace ServiceBus.Rabbit
{
    public sealed class BusProducer : IBusProducer, IDisposable
    {
        private readonly ILogger<BusProducer> logger;
        private readonly ServiceBusConnection connection;
        private readonly Action<IModel> declareExchange;
        private IModel? channel;

        private bool disposed;

        public BusProducer(ServiceBusConnection connection, Action<IModel> declareExchange, ILogger<BusProducer> logger)
        {
            this.connection = connection;
            this.logger = logger;
            this.declareExchange = declareExchange;
        }

        public void Start()
        {
            channel = connection.Connection.CreateModel();
            declareExchange(channel);
        }

        public void Send(string topic, string replyTopic, byte[] messageBody, Guid requestId)
        {
            SendMessage(topic, ServiceBusConnection.RequestExchange, messageBody, properties =>
            {
                properties.CorrelationId = requestId.ToString();
                properties.ReplyTo = replyTopic;
            });
        }

        public void Reply(string topic, byte[] messageBody, Guid requestId)
        {
            SendMessage(topic, ServiceBusConnection.RequestExchange, messageBody, properties =>
            {
                properties.CorrelationId = requestId.ToString();
            });
        }

        public void Publish(string topic, byte[] messageBody)
        {
            SendMessage(topic, ServiceBusConnection.EventExchange, messageBody, builder => { });
        }

        private void SendMessage(string topic, string exchange, byte[] messageBody, Action<IBasicProperties> builder)
        {
            if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendRequest"); }

            logger.LogInformation("Sending message to {topic}", topic);

            var props = channel!.CreateBasicProperties();
            props.ContentType = "application/json";
            props.DeliveryMode = 2;

            builder(props);

            channel.BasicPublish(exchange: exchange,
                routingKey: topic,
                basicProperties: props,
                body: messageBody);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                channel?.Dispose();
            }
        }
    }
}
