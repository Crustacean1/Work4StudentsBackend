using Microsoft.Extensions.Hosting;

namespace ServiceBus.Rabbit
{
    public interface IServiceBusReceiver : IHostedService
    {
        public void RegisterEventHandler<T>(T handler);
    }
}
