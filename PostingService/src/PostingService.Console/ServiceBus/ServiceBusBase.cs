using System;
using System.Text;
using RabbitMQ.Client;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusBase : IDisposable
    {
        private bool disposed;
        protected readonly IModel channel;

        public ServiceBusBase(IConnection connection, string topic)
        {
            channel = connection.CreateModel();
            _ = channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    channel.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
    }
}
