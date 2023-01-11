using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Models;
using W4S.ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [BusService("offer")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;
        IJobService jobService;

        public JobOfferHandler(IJobService jobService, ILogger<JobOfferHandler> logger)
        {
            logger.LogInformation("Creation");
            this.logger = logger;
            this.jobService = jobService;
        }

        [BusRequestHandler("create")]
        public async Task<JobOfferCreatedDto> OnPostJobOffer(PostJobOfferCommand offer)
        {
            logger.LogInformation("Received job creation request");

            var newJobId = await jobService.PostJobOffer(offer);

            return new JobOfferCreatedDto
            {
                Id = newJobId
            };
        }
    }

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
    }
}
