using System;

namespace PostingService.Console.ServiceBus
{
    public static class ServiceBusExtension
    {
        public static void AddServiceBusHandler(this IServiceCollection provider)
        {
          provider.AddSingleton<ServiceBusClientFactory>();
          provider.AddSingleton<ServiceBusClientFactory>();
        }
    }
}
