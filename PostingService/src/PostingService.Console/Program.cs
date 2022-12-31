using PostingService.Console.Handlers;
using PostingService.Domain.Commands;
using PostingService.Domain.Repositories;
using PostingService.Persistence.Repositories;
using PostingService.Persistence;
using W4S.ServiceBus.Extensions;

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
                  provider.AddScoped<CreateJobOfferCommand>();
                  provider.AddScoped<PostingContext>();
                  provider.AddScoped<IJobOfferRepository, JobOfferRepository>();
                  provider.AddScoped<JobOfferHandler>();
                  provider.AddScoped<UserIntegrationHandler>();
                  provider.AddServiceBus();
              })
            .RunConsoleAsync();
        }
    }
}


