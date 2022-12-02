using ServiceBus.Rabbit;

namespace PostingService.Console.Controllers
{
    public class PostingHost : IHostedService
    {
        private readonly ILogger<PostingHost> logger;
        private readonly IServiceBusSender sender;

        public PostingHost(ILogger<PostingHost> logger,
                           IServiceBusSender sender)
        {
            this.logger = logger;
            this.sender = sender;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
          object test = new();
          sender.SendEvent(test);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
