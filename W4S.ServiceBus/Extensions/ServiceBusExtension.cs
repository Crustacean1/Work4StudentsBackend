using Microsoft.Extensions.DependencyInjection;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Package;
using W4S.ServiceBus.Rabbit;

namespace W4S.ServiceBus.Extensions
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
