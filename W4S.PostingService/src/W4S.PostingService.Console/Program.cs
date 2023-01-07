using PostingService.Console.Handlers;
using W4S.PostingService.Domain.Repositories;
using PostingService.Persistence;
using W4S.ServiceBus.Extensions;
using W4S.PostingService.Domain.Services;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Persistence.Repositories;

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
                  provider.AddScoped<JobService>();
                  provider.AddScoped<PostingContext>();
                  provider.AddScoped<IRepository<JobOffer>, RepositoryBase>();
                  provider.AddScoped<JobOfferHandler>();
                  provider.AddScoped<UserIntegrationHandler>();
                  provider.AddServiceBus();
              })
            .RunConsoleAsync();
        }
    }
}


