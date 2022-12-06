using System.Text;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ServiceBus.Rabbit
{
    public sealed class ServiceBusSender : IServiceBusSender, IDisposable
    {
        private readonly ILogger<ServiceBusSender> logger;
        private readonly ServiceBusConnection connection;
        private IModel? channel;

        private bool disposed;
        private object disposeLock = new();

        public ServiceBusSender(ServiceBusConnection connection, ILogger<ServiceBusSender> logger)
        {
            this.connection = connection;
            this.logger = logger;
        }

        public void SendEvent<T>(string topic, T busEvent) where T : class
        {
            lock (disposeLock)
            {
                if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendEvent"); }

                LazyInitialize();

                string message = JsonSerializer.Serialize(busEvent);
                byte[] body = Encoding.UTF8.GetBytes(message);

                logger.LogInformation("Send: {Message} with topic: {Topic}", message, topic);

                channel.BasicPublish(exchange: ServiceBusConnection.DefaultExchange,
                    routingKey: topic,
                    basicProperties: null,
                    body: body);
            }
        }

        public Task<TResult> SendRequest<TRequest, TResult>(string topic, TRequest request) where TResult : class, new()
        {
            lock (disposeLock)
            {
                if (disposed) { throw new ObjectDisposedException("ServiceBusSender.SendRequest"); }

                LazyInitialize();

                string message = JsonSerializer.Serialize(busEvent);
                byte[] body = Encoding.UTF8.GetBytes(message);

                logger.LogInformation("Send: {Message} with topic: {Topic}", message, topic);

                channel.BasicPublish(exchange: ServiceBusConnection.DefaultExchange,
                    routingKey: topic,
                    basicProperties: null,
                    body: body);
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                channel?.Dispose();
            }
        }

        private void LazyInitialize()
        {
            if (channel is null)
            {
                channel = connection.Connection.CreateModel();
                channel.ExchangeDeclare(
                    ServiceBusConnection.DefaultExchange,
                    ServiceBusConnection.DefaultExchangeType);
            }
        }
    }
}
