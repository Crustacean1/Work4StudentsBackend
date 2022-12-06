using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Package;
using System.Text.Json;
using System.Reflection;

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

        public void Start()
        {
            lock (disposeLock)
            {
                if (disposed) { throw new ObjectDisposedException("ServiceBusReceiver"); }

                StartConsumer();
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

        private void OnMessage(object? _, BasicDeliverEventArgs args)
        {

            string messageTopic = args.RoutingKey;
            byte[] body = args.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            logger.LogInformation("Received message: {Message} with topic: {Topic}", message, messageTopic);

            using (var scope = provider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService(handlerType);

                MethodInfo? method = handler.GetType()
                    .GetMethods()
                    .SingleOrDefault(method =>
                            Attribute.GetCustomAttributes(method, typeof(ServiceBusEventHandlerAttribute))
                            .Any(attr => attr is ServiceBusEventHandlerAttribute attribute && attribute.EventName == messageTopic));

                if (method is null)
                {
                    logger.LogInformation("No suitable method found for topic: {Topic}", messageTopic);
                    return;
                }

                logger.LogInformation("Executing handler method {Name}", method.Name);

                if (InvokeMethod(handler, method, message, out var result))
                {
                    ReturnFromMethod(result, args.BasicProperties, args.DeliveryTag);
                }
                else
                {
                    channel!.BasicAck(args.DeliveryTag, multiple: false);
                }
            }
        }

        private bool InvokeMethod(object? caller, MethodInfo method, string rawParameter, out object? result)
        {
            ParameterInfo? parameterType = method.GetParameters().SingleOrDefault();

            object[] arguments;

            if (parameterType is null)
            {
                arguments = Array.Empty<object>();
            }
            else
            {
                dynamic? eventInstance = JsonSerializer.Deserialize(rawParameter, parameterType.ParameterType);
                if (eventInstance is null) { throw new InvalidOperationException("Couldn't deserialize empty event"); }
                arguments = new object[] { eventInstance };
            }

            if (!method.ReturnType.Equals(typeof(void)))
            {
                result = method.Invoke(caller, arguments);
                return false;
            }
            else
            {
                _ = method.Invoke(caller, arguments);
                result = null;
                return false;
            }
        }

        private void ReturnFromMethod<T>(T result, IBasicProperties props, ulong deliveryTag)
        {
            var replyProps = channel!.CreateBasicProperties();
            var serializedResult = JsonSerializer.Serialize(result);
            byte[] serializedResultBuffer = Encoding.UTF8.GetBytes(serializedResult);

            replyProps.CorrelationId = props.CorrelationId;

            logger.LogInformation("Replying to message");

            channel.BasicPublish(exchange: ServiceBusConnection.DefaultExchange,
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: serializedResultBuffer);
            channel.BasicAck(deliveryTag: deliveryTag, multiple: false);
        }

        private void StartConsumer()
        {
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
    }
}
