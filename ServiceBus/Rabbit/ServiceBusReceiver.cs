using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Rabbit
{
    public sealed class ServiceBusReceiver : IServiceBusReceiver
    {
        private readonly ServiceBusConnection serviceBusConnection;
        private readonly IServiceProvider provider;
        private readonly ILogger logger;
        private readonly Type handlerType;
        private readonly string topic;

        private IModel? channel;

        private bool disposed;
        private readonly object disposeLock = new();

        public ServiceBusReceiver(IServiceProvider provider, ILogger logger, Type handlerType, ServiceBusConnection serviceBusConnection, string topic)
        {
            this.provider = provider;
            this.logger = logger;
            this.handlerType = handlerType;
            this.serviceBusConnection = serviceBusConnection;
            this.topic = topic;
        }

        public void StartAsync()
        {
            lock (disposeLock)
            {
                if (disposed) { throw new ObjectDisposedException("ServiceBusReceiver"); }

                channel = serviceBusConnection.Connection.CreateModel();

                channel.ExchangeDeclare(exchange: ServiceBusConnection.DefaultExchange, type: ExchangeType.Direct);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: ServiceBusConnection.DefaultExchange, routingKey: topic);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += OnMessage;

                _ = channel.BasicConsume(queue: topic, autoAck: true, consumer: consumer);
            }
        }


        private void OnMessage(object? _, BasicDeliverEventArgs args)
        {
            string? message;
            string? messageTopic;

            lock (disposeLock)
            {
                if (disposed) { throw new ObjectDisposedException("ServiceBusReceiver"); }

                messageTopic = args.RoutingKey;
                var body = args.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                logger.LogInformation("Received message with topic: {Topic}", args.RoutingKey);
            }

            using (var scope = provider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var method = handler.GetType()
                    .GetMethods()
                    .SingleOrDefault(method =>
                            Attribute.GetCustomAttributes(method, typeof(ServiceBusEventHandlerAttribute))
                            .Any(attr => attr is ServiceBusEventHandlerAttribute attribute && attribute.EventName == messageTopic));

                if (method is not null)
                {
                    _ = method.Invoke(handler, new object[1]);
                }

            }
        }

        public void Dispose()
        {
            lock (disposeLock)
            {
                if (!disposed)
                {
                    channel?.Dispose();
                    disposed = true;
                }
            }
        }
    }
}
