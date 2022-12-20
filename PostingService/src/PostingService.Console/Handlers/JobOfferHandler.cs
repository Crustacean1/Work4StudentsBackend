using ServiceBus.Attributes;
using PostingService.Console.Dto;
using PostingService.Domain.Commands;
using PostingService.Domain.Models;

namespace PostingService.Console.Handlers
{
    [ServiceBusHandler("offers")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;
        CreateJobOfferCommand jobOfferCommand;

        public JobOfferHandler(CreateJobOfferCommand jobOfferCommand, ILogger<JobOfferHandler> logger)
        {
            logger.LogInformation("Creation");
            this.logger = logger;
            this.jobOfferCommand = jobOfferCommand;
        }

        [ServiceBusMethod("create")]
        public JobOfferCreatedDto OnCreateJobOffer(CreateJobOfferDto offer)
        {
            logger.LogInformation("Received job creation request");
            var newJobOffer = new JobOffer
            {
                Title = offer.Title,
                Content = offer.Content
            };
            return new JobOfferCreatedDto {Id = Guid.Empty};
        }
    }

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
    }
}
