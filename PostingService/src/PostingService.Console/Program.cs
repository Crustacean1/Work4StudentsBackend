using Microsoft.Extensions.Hosting;
using PostingService.Console.ServiceBus;
using Microsoft.Extensions.Logging;
using PostingService.Console.Controllers;

namespace PostingService.Console
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            await new HostBuilder()
              .ConfigureLogging(builder =>
              {
                  builder.ClearProviders()
                         .AddConsole();
              })
              .ConfigureServices(provider =>
              {
                  provider.AddServiceBus()
                          .AddServiceBusClient("shitposting")
                          .AddServiceBusHandler("shitposting");

                  provider.AddHostedService<PostingHost>();
              })
            .RunConsoleAsync();
        }
    }
}


