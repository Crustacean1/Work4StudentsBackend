using W4S.PostingService.Console.Dto;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.Services;
using W4S.ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [BusService("offer")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;
        JobService jobOfferCommand;

        public JobOfferHandler(JobService jobOfferCommand, ILogger<JobOfferHandler> logger, )
        {
            logger.LogInformation("Creation");
            this.logger = logger;
            this.jobOfferCommand = jobOfferCommand;
        }

        [BusRequestHandler("create")]
        public JobOfferCreatedDto OnCreateJobOffer(CreateJobOfferCommand offer)
        {
            logger.LogInformation("Received job creation request");


            return new JobOfferCreatedDto
            {
                Offer = newJobOffer
            };
        }
    }

    public class JobOfferCreatedDto
    {
        public JobOffer Offer { get; set; }
    }
}
