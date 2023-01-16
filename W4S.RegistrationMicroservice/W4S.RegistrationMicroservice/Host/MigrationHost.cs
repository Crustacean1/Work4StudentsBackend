using W4S.RegistrationMicroservice.Data.DbContexts;

namespace W4S.RegistrationMicroservice.API.Host
{
    public class MigrationHost : IHostedService
    {
        private readonly UserbaseDbContext dbContext;
        private readonly ILogger<MigrationHost> logger;

        public MigrationHost(UserbaseDbContext dbContext, ILogger<MigrationHost> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await dbContext.MigrateAsync(cancellationToken);
            logger.LogInformation("Migration executed");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
