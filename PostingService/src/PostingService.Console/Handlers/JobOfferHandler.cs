using PostingService.Console.Dto;
using PostingService.Domain.Commands;
using PostingService.Domain.Models;
using W4S.ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [BusService("offer")]
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

        [BusRequestHandler("create")]
        public JobOfferCreatedDto OnCreateJobOffer(CreateJobOfferDto offer)
        {
            logger.LogInformation("Received job creation request");
            var newJobOffer = new JobOffer
            {
                Title = offer.Title,
                Content = offer.Content
            };
            return new JobOfferCreatedDto { Id = Guid.Empty };
        }
    }

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
    }
}
