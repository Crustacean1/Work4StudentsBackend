using PostingService.Console.Handlers;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Persistence;
using W4S.ServiceBus.Extensions;
using W4S.PostingService.Domain.Services;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Persistence.Repositories;
using Serilog;
using Serilog.Events;
using W4S.PostingService.Domain.Abstractions;

namespace W4S.PostingService.Console
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

            var host = new HostBuilder()
              .ConfigureServices(provider =>
              {
                  provider.AddScoped<IJobService, JobService>();
                  provider.AddScoped<PostingContext>();
                  provider.AddScoped<IRepository<JobOffer>, RepositoryBase<JobOffer>>();
                  provider.AddScoped<IRepository<Applicant>, RepositoryBase<Applicant>>();
                  provider.AddScoped<IRepository<Recruiter>, RepositoryBase<Recruiter>>();
                  provider.AddScoped<IRepository<Application>, RepositoryBase<Application>>();
                  provider.AddScoped<JobOfferHandler>();
                  provider.AddHostedService<MigrationHost>();
                  provider.AddServiceBus();
              })
            .UseSerilog()
            .Build();

            await host.RunAsync();
        }
    }
}


