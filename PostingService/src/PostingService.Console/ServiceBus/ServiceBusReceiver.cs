using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusReceiver : ServiceBusBase, IHostedService, IServiceBusReceiver
    {
        private readonly ILogger logger;

        public ServiceBusReceiver(IConnection connection, string topic, ILogger<ServiceBusReceiver> logger) : base(connection, topic)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_OnEvent;
            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

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
