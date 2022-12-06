using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace ServiceBus.Rabbit
{
    public interface IServiceBusReceiver : IDisposable
    {
        public void Start();
    }
}
