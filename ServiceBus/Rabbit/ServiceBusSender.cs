using System;
using System.Text;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace ServiceBus.Rabbit
{
    public class ServiceBusSender : IServiceBusSender
    {
        private readonly ILogger<ServiceBusSender> logger;
        private readonly string topic;
        private readonly IModel channel;

        public ServiceBusSender(ServiceBus bus, string topic, ILogger<ServiceBusSender> logger)
        {
            channel = bus.Channel;
            this.topic = topic;
            this.logger = logger;
        }

        public void SendEvent<T>(T busEvent) where T : class
        {
            channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);

            string message = "Hello World";
            var body = Encoding.UTF8.GetBytes(message);
            logger.LogInformation("Send: {Message}", message);

            channel.BasicPublish(exchange: "",
                routingKey: topic,
                basicProperties: null,
                body: body);
        }

        public Task<TResult> SendRequest<TRequest, TResult>(TRequest request) where TResult : class, new()
        {
            throw new NotImplementedException("");
        }
    }
}
