using System;
using System.Text;
using RabbitMQ.Client;

namespace PostingService.Console.ServiceBus
{
    public class ServiceBusSender : ServiceBusBase, IServiceBusSender
    {
        public ServiceBusSender(IConnection connection, string topic) : base(connection, topic)
        {
        }

        public void SendEvent<T>(T busEvent)
        {
            var body = Encoding.UTF8.GetBytes("Hello World");

            channel.BasicPublish(exchange: "",
                routingKey: "sender-offender",
                basicProperties: null,
                body: body);
        }

        public Task<TResult> SendRequest<TRequest, TResult>(TRequest request) where TResult : new()
        {
            throw new NotImplementedException("");
        }
    }
}
