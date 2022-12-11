using System.Text;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using RabbitMQ.Client.Events;
using ServiceBus.Events;
using ServiceBus.Abstractions;

namespace ServiceBus.Rabbit
{
    public sealed class BusClient : IBusClient, IDisposable
    {
        private readonly ILogger<BusClient> logger;
        private readonly ServiceBusConnection connection;
        private IModel? channel;

        private bool disposed;
        private readonly object disposeLock = new();
        private string? replyQueueName;
        private EventingBasicConsumer? consumer;

        public event EventHandler<ResponseReceivedArgs>? ResponseReceived;


        public BusClient(ServiceBusConnection connection, ILogger<BusClient> logger)
        {
            this.connection = connection;
            this.logger = logger;
        }

        public BusClient Start()
        {
            channel = connection.Connection.CreateModel();

            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnReply;
            _ = channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);
            return this;
        }

        public void SendEvent(string topic, string eventBody)
        {
            if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendEvent"); }

            byte[] body = Encoding.UTF8.GetBytes(eventBody);

            var props = channel!.CreateBasicProperties();
            props.ContentType = "application/json";

            logger.LogInformation("Sending event with topic: {Topic}", topic);

            channel.BasicPublish(exchange: ServiceBusConnection.DefaultExchange,
                routingKey: topic,
                basicProperties: props,
                body: body);
        }

        public void SendRequest(string topic, Guid requestId, string requestBody)
        {
            if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendRequest"); }

            byte[] body = Encoding.UTF8.GetBytes(requestBody);

            var props = channel!.CreateBasicProperties();
            props.ContentType = "application/json";
            props.ReplyTo = replyQueueName;
            props.CorrelationId = requestId.ToString();


            channel.BasicPublish(exchange: ServiceBusConnection.DefaultExchange,
                routingKey: topic,
                basicProperties: props,
                body: body);
        }

        public void SendResponse(string responseQueue, Guid requestId, string responseBody)
        {
            if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendRequest"); }
            var response = Encoding.UTF8.GetBytes(responseBody);
            var props = channel!.CreateBasicProperties();
            props.ContentType = "application/json";
            props.CorrelationId = requestId.ToString();

            channel.BasicPublish(exchange: "", routingKey: responseQueue, basicProperties: props, body: response);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                channel?.Dispose();
            }
        }

        public void OnReply(object? _, BasicDeliverEventArgs args)
        {
            ResponseReceived?.Invoke(this, new ResponseReceivedArgs
            {
                ResponseBody = Encoding.UTF8.GetString(args.Body.ToArray()),
                RequestId = Guid.Parse(args.BasicProperties.CorrelationId)
            });
        }
    }
}
