using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Persistence;
using W4S.ServiceBus.Extensions;
using W4S.PostingService.Persistence.Repositories;
using Serilog;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Console.Handlers;
using System.Globalization;
using W4S.PostingService.Domain.Commands;
using MediatR;

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
                  provider.AddDbContext<PostingContext>();
                  provider.AddScoped<IRepository<JobOffer>, RepositoryBase<JobOffer>>();
                  provider.AddScoped<IRepository<Student>, RepositoryBase<Student>>();
                  provider.AddScoped<IRepository<Recruiter>, RepositoryBase<Recruiter>>();
                  provider.AddScoped<IRepository<Application>, RepositoryBase<Application>>();
                  provider.AddScoped<IRepository<Company>, RepositoryBase<Company>>();
                  provider.AddScoped<IReviewRepository<OfferReview>, ReviewRepository<OfferReview>>();
                  provider.AddScoped<IReviewRepository<ApplicationReview>, ReviewRepository<ApplicationReview>>();

                  provider.AddScoped<OfferHandler>();
                  provider.AddScoped<ApplicationHandler>();
                  provider.AddScoped<ReviewHandler>();
                  provider.AddScoped<ProfileIntegrationHandler>();
                  provider.AddHostedService<MigrationHost>();

                  provider.AddMediatR(typeof(PostOfferCommandHandler));

                  provider.AddServiceBus();
              })
            .Build();

            await host.RunAsync();
        }
    }
}


