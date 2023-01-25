using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Persistence;
using W4S.ServiceBus.Extensions;
using W4S.PostingService.Domain.Services;
using W4S.PostingService.Persistence.Repositories;
using Serilog;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Console.Handlers;
using W4s.PostingService.Domain.Services;
using System.Globalization;

namespace W4S.PostingService.Console
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Console(formatProvider: new CultureInfo("pl-PL"))
                        .CreateLogger();

            var host = new HostBuilder()
                .UseSerilog()
              .ConfigureServices(provider =>
              {
                  provider.AddScoped<IJobService, JobService>();
                  provider.AddScoped<IApplicationService, ApplicationService>();
                  provider.AddScoped<IProfileIntegrationService, ProfileIntegrationService>();
                  provider.AddDbContext<PostingContext>();
                  provider.AddScoped<IRepository<JobOffer>, RepositoryBase<JobOffer>>();
                  provider.AddScoped<IRepository<Applicant>, RepositoryBase<Applicant>>();
                  provider.AddScoped<IRepository<Recruiter>, RepositoryBase<Recruiter>>();
                  provider.AddScoped<IRepository<Application>, RepositoryBase<Application>>();
                  provider.AddScoped<IRepository<Company>, RepositoryBase<Company>>();
                  provider.AddScoped<JobOfferHandler>();
                  provider.AddScoped<ApplicationHandler>();
                  provider.AddScoped<ProfileIntegrationHandler>();
                  provider.AddHostedService<MigrationHost>();
                  provider.AddServiceBus();
              })
            .Build();

            await host.RunAsync();
        }
    }
}


