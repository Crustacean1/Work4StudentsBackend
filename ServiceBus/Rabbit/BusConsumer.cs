using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
using ServiceBus.Events;
using ServiceBus.Abstractions;

namespace ServiceBus.Rabbit
{
    public sealed class BusConsumer : IBusConsumer, IDisposable
    {
        private readonly ServiceBusConnection serviceBusConnection;
        private readonly ILogger<BusConsumer> logger;

        private IModel? channel;

        private readonly string queueName;
        private readonly string topic;
        private readonly string exchange;
        private readonly Action<IModel> declareExchange;

        private bool disposed;

        public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

        public BusConsumer(ServiceBusConnection serviceBusConnection, Action<IModel> declareExchange, string queueName, string topic, string exchange, ILogger<BusConsumer> logger)
        {
            this.logger = logger;
            this.serviceBusConnection = serviceBusConnection;
            this.declareExchange = declareExchange;
            this.queueName = queueName;
            this.topic = topic;
            this.exchange = exchange;
        }

        public void Start()
        {
            logger.LogInformation("Starting consuming topic: {Topic}", topic);

            if (disposed) { throw new ObjectDisposedException("ServiceBusReceiver"); }

            channel = serviceBusConnection.Connection.CreateModel();

            declareExchange(channel);

            channel.QueueDeclare(queue: queueName,
                                 exclusive: false,
                                 durable: true,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            channel.QueueBind(queue: queueName, exchange: exchange, routingKey: topic);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnMessage;

            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
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
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(args));
        }
    }
}
