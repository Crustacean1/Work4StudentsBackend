using RabbitMQ.Client;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusClient : IServiceBusClient
    {


        public ServiceBusClient(IConnection connection, string topic)
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void SendEvent<T>(T busEvent)
        {

        }

        public Task<TResult> SendRequest<TRequest, TResult>(TRequest request) where TResult : new()
        {
            return Task.FromResult(new TResult());
        }
    }
}
