using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Rabbit
{
    public static class ServiceBusExtension
    {
        private static HandlerContainer handlerContainer = new();

        public static IServiceCollection AddServiceBus(this IServiceCollection collection)
        {
            return collection.AddSingleton<ServiceBusConnection>()
                .AddSingleton<HandlerContainer>()
              .AddHostedService<IServiceBusReceiver>();
        }

        public static IServiceCollection AddServiceBusClient(this IServiceCollection collection, string topic)
        {
            return collection.AddSingleton<IServiceBusSender>();
        }

        public static IServiceCollection AddServiceBusHandler<THandler>(this IServiceCollection provider, string topic) where THandler : class
        {
            handlerContainer.AddHandler(new Handler { HandlerName = topic, HandlerType = typeof(THandler) });
            return provider.AddTransient<THandler>();
        }
    }
}
