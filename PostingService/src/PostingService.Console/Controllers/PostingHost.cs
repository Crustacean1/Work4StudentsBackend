using RabbitMQ.Client;

namespace PostingService.Console.Controllers
{
    public class PostingHost : IHostedService
    {
        private readonly ILogger<PostingHost> logger;

        public PostingHost(ILogger<PostingHost> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting host");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping host");
            return Task.CompletedTask;
        }
    }
}
