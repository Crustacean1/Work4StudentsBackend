using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Abstractions;
using ServiceBus.Package;
using ServiceBus.Rabbit;

namespace ServiceBus.Extensions
{
    public static class ServiceBusExtension
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection collection)
        {
            return collection.AddSingleton<ServiceBusConnection>()
                .AddSingleton<IClient, Client>()
                .AddSingleton<IServiceBusFactory, ServiceBusFactory>()
                .AddHostedService<ServiceBusReceiverContainer>();
        }
    }
}
