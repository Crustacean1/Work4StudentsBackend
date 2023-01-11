using W4SRegistrationMicroservice.Data.DbContexts;

namespace W4S.RegistrationMicroservice.API.Host
{
    public class MigrationHost : IHostedService
    {
        private readonly W4SUserbaseDbContext dbContext;

        public MigrationHost(W4SUserbaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await dbContext.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
