using PostingService.Persistence;

namespace PostingService.Console.Commands
{
    public class CreateJobOfferCommand
    {
        private readonly ILogger<CreateJobOfferCommand> logger;
        private readonly IJobOfferRepository repository;

        public CreateJobOfferCommand(ILogger<CreateJobOfferCommand> logger, IJobOfferRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
    }
}
