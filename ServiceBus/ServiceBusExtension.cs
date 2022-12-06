using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Package;
using ServiceBus.Rabbit;

namespace ServiceBus
{
    public static class ServiceBusExtension
    {
        private static readonly HandlerContainer handlerContainer = new();

        public static IServiceCollection AddServiceBus(this IServiceCollection collection)
        {
            return collection.AddSingleton<ServiceBusConnection>()
                .AddSingleton(_ => handlerContainer)
                .AddHostedService<ServiceBusReceiverContainer>();
        }

        public static IServiceCollection AddServiceBusClient(this IServiceCollection collection)
        {
            return collection.AddSingleton<IServiceBusSender, ServiceBusSender>();
        }

        public static IServiceCollection AddServiceBusHandler<THandler>(this IServiceCollection provider, string topic) where THandler : class
        {
            handlerContainer.AddHandler(new Handler { HandlerName = topic, HandlerType = typeof(THandler) });
            return provider.AddScoped<THandler>();
        }
    }
}
