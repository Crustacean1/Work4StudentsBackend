using W4S.RegistrationMicroservice.Data.DbContexts;
using W4SRegistrationMicroservice.Data.Seeders.Interface;

namespace W4S.RegistrationMicroservice.API.Host
{
    public class MigrationHost : IHostedService
    {
        private readonly W4SUserbaseDbContext dbContext;
        private readonly ILogger<MigrationHost> logger;
        private readonly IServiceProvider serviceProvider;

        public MigrationHost(W4SUserbaseDbContext dbContext, IServiceProvider serviceProvider, ILogger<MigrationHost> logger)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await dbContext.MigrateAsync(cancellationToken);
            logger.LogInformation("Migration executed");

            using (var scope = serviceProvider.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<ISeeder>();
                dbInitializer.Seed();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
