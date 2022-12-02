using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace ServiceBus.Rabbit
{
    public class ServiceBusReceiver : IHostedService, IServiceBusReceiver
    {
        private readonly ILogger logger;
        private readonly IModel channel;
        private readonly string topic;

        public ServiceBusReceiver(ServiceBus serviceBus, string topic, ILogger<ServiceBusReceiver> logger)
        {
            channel = serviceBus.Channel;
            this.logger = logger;
            this.topic = topic;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_OnEvent;

            channel.BasicConsume(queue: topic, autoAck: true, consumer: consumer);

            logger.LogInformation("Started listening on topic: {Topic}", topic);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void RegisterEventHandler<T>(T handler)
        {
            throw new NotImplementedException();
        }

        private void Consumer_OnEvent(object? model, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            logger.LogInformation("Received: {Message}", message);
        }
    }
}
