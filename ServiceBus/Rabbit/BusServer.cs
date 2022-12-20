using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
using ServiceBus.Events;
using ServiceBus.Abstractions;

namespace ServiceBus.Rabbit
{
    public sealed class BusServer : IBusServer, IDisposable
    {
        private readonly ServiceBusConnection serviceBusConnection;
        private readonly ILogger<BusServer> logger;

        private IModel? channel;

        private bool disposed;

        public event EventHandler<EventReceivedArgs>? EventReceived;
        public event EventHandler<RequestReceivedArgs>? RequestReceived;

        public BusServer(ServiceBusConnection serviceBusConnection, ILogger<BusServer> logger)
        {
            this.logger = logger;
            this.serviceBusConnection = serviceBusConnection;
        }

        public void Start(string topic)
        {
            logger.LogInformation("Starting ServiceBus Server listening on topic: {Topic}", topic);

            if (disposed) { throw new ObjectDisposedException("ServiceBusReceiver"); }

            channel = serviceBusConnection.Connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: ServiceBusConnection.DefaultExchange,
                type: ServiceBusConnection.DefaultExchangeType);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: ServiceBusConnection.DefaultExchange, routingKey: topic);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnMessage;

            _ = channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                channel?.Dispose();
                disposed = true;
            }
        }

        private void OnMessage(object? _, BasicDeliverEventArgs args)
        {
            logger.LogInformation("Received message: {Topic}", args.RoutingKey);
            if (string.IsNullOrEmpty(args.BasicProperties.ReplyTo))
            {
                EventReceived?.Invoke(this, new EventReceivedArgs
                {
                    Topic = args.RoutingKey,
                    EventBody = Encoding.UTF8.GetString(args.Body.ToArray())
                });
            }
            else
            {
                RequestReceived?.Invoke(this, new RequestReceivedArgs
                {
                    Topic = args.RoutingKey,
                    ReplyTopic = args.BasicProperties.ReplyTo,
                    RequestBody = Encoding.UTF8.GetString(args.Body.ToArray()),
                    RequestId = Guid.Parse(args.BasicProperties.CorrelationId)
                });
            }
        }
    }
}
