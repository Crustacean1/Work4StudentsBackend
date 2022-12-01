namespace PostingService.Console.ServiceBus
{
    public static class ServiceBusExtension
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection provider)
        {
            return provider.AddSingleton<ServiceBusFactory>();
        }

        public static IServiceCollection AddServiceBusClient(this IServiceCollection provider, string topic)
        {
            return provider.AddSingleton<IServiceBusSender>(p => p.GetService<ServiceBusFactory>()?.CreateClient(topic)
                                                          ?? throw new InvalidOperationException("'AddServiceBusHandler' must be run before any service bus client is added"));
        }

        public static IServiceCollection AddServiceBusHandler(this IServiceCollection provider, string topic)
        {
            return provider.AddHostedService<ServiceBusReceiver>(p => p.GetService<ServiceBusFactory>()?.CreateReceiver(p, topic)
                                                                ?? throw new InvalidOperationException("'AddServiceBusHandler' must be run before any service bus client is added"));
        }
    }
}
