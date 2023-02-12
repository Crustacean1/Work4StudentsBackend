using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Persistence;
using W4S.ServiceBus.Extensions;
using W4S.PostingService.Persistence.Repositories;
using Serilog;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Console.Handlers;
using System.Globalization;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Queries;

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
                  provider.AddScoped<OfferHandler>();
                  provider.AddScoped<ApplicationHandler>();
                  provider.AddScoped<ProfileIntegrationHandler>();
                  provider.AddHostedService<MigrationHost>();

                  AddCommandHandlers(provider);

                  AddQueryHandlers(provider);

                  provider.AddServiceBus();
              })
            .Build();

            await host.RunAsync();
        }

        public static void AddCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<PostOfferCommandHandler>();
            services.AddScoped<UpdateOfferCommandHandler>();
            services.AddScoped<SubmitApplicationCommandHandler>();
            services.AddScoped<WithdrawApplicationCommandHandler>();
        }

        public static void AddQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<GetOfferApplicationsQueryHandler>();
            services.AddScoped<GetOfferQueryHandler>();
            services.AddScoped<GetOffersQueryHandler>();
            services.AddScoped<GetRecruiterOffersQueryHandler>();
            services.AddScoped<GetStudentApplicationsQueryHandler>();
            services.AddScoped<RegisterStudentCommandHandler>();
            services.AddScoped<RegisterRecruiterCommandHandler>();
        }
    }
}


