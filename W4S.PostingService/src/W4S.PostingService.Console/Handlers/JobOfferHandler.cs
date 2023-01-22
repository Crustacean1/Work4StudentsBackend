using W4S.PostingService.Domain.Responses;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.ValueType;
using W4S.ServiceBus.Attributes;
using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("offer")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;
        IJobService jobService;

        public JobOfferHandler(IJobService jobService, ILogger<JobOfferHandler> logger)
        {
            logger.LogInformation("Creation");
            this.logger = logger; this.jobService = jobService;
        }

        [BusRequestHandler("post")]
        public async Task<JobOfferCreatedDto> OnPostJobOffer(PostJobOfferCommand offer)
        {
            logger.LogInformation("Recruiter: {Recruiter} posts job offer titled: {Title}", offer.RecruiterId, offer.Title);

            var notification = new Notification();
            var newJobId = await jobService.PostJobOffer(offer, notification);

            return new JobOfferCreatedDto
            {
                Id = newJobId,
                Errors = notification.ErrorMessages.ToList()
            };
        }

        [BusRequestHandler("list")]
        public async Task<JobOffersDto> GetOfferListing(JobOffersQuery query)
        {
            var offers = await jobService.ListJobOffers(query);
            return new JobOffersDto { JobOffers = offers };
        }
    }
}
