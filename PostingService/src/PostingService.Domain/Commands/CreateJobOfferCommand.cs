using PostingService.Domain.Models;
using Microsoft.Extensions.Logging;
using PostingService.Domain.Repositories;

namespace PostingService.Domain.Commands
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

        public Guid CreateJobOffer(JobOffer offer)
        {
            logger.LogInformation("Creating new job offer");
            repository.AddJobOffer(offer);
            return Guid.Empty;
        }
    }
}
