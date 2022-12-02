using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Rabbit
{
    public static class ServiceBusExtension
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection provider)
        {
            return provider.AddSingleton<ServiceBus>();
        }

        public static IServiceCollection AddServiceBusClient(this IServiceCollection provider, string topic)
        {
            return provider.AddSingleton<IServiceBusSender>(p => new ServiceBusSender(
                  p.GetService<ServiceBus>()!,
                  topic,
                  p.GetService<ILogger<ServiceBusSender>>()
                  ));
        }

        public static IServiceCollection AddServiceBusHandler(this IServiceCollection provider, string topic)
        {
            return provider.AddHostedService<IServiceBusReceiver>(p => new ServiceBusReceiver(
                  p.GetService<ServiceBus>()!,
                  topic,
                  p.GetService<ILogger<ServiceBusReceiver>>()
                  ));
        }
    }
}
