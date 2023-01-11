using Microsoft.Extensions.Hosting;

namespace W4S.PostingService.Persistence
{
    public class MigrationHost : IHostedService
    {
        private readonly PostingContext context;

        public MigrationHost(PostingContext context)
        {
            this.context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await context.MigrateAsync(cancellationToken);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
