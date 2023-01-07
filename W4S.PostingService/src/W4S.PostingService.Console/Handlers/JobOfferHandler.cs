using PostingService.Console.Dto;
using PostingService.Domain.Models;
using W4S.PostingService.Domain.Services;
using W4S.ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [BusService("offer")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;
        JobService jobOfferCommand;

        public JobOfferHandler(JobService jobOfferCommand, ILogger<JobOfferHandler> logger)
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
            return new JobOfferCreatedDto { Id = offer.PosterId };
        }
    }

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
    }
}
