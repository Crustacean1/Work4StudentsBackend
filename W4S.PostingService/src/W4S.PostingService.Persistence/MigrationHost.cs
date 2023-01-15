using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace W4S.PostingService.Persistence
{
    public class MigrationHost : IHostedService
    {
        private readonly PostingContext context;
        private readonly ILogger<MigrationHost> logger;

        public MigrationHost(PostingContext context, ILogger<MigrationHost> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting migration");
            await context.MigrateAsync(cancellationToken);
            logger.LogInformation("Migration done");
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
