using PostingService.Console.Handlers;
using ServiceBus.Extensions;

namespace PostingService.Console
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            await new HostBuilder()
              .ConfigureLogging(builder =>
              {
                  _ = builder.ClearProviders()
                         .AddConsole();
              })
              .ConfigureServices(provider =>
              {
                  provider.AddScoped<UserCreationHandler>();
                  provider.AddScoped<JobOfferHandler>();
                  provider.AddServiceBus();
              })
            .RunConsoleAsync();
        }
    }
}


