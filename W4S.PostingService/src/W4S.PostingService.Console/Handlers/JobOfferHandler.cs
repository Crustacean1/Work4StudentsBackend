using W4S.PostingService.Domain.Responses;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;
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
            logger.LogInformation("Posting job offer {Title} by {Recruiter}", offer.Title, offer.RecruiterId);

            var notification = new Notification();
            var newJobId = await jobService.PostJobOffer(offer, notification);

            return new JobOfferCreatedDto
            {
                Id = newJobId,
                Errors = notification.ErrorMessages.ToList()
            };
        }

        [BusRequestHandler("apply")]
        public async Task<ApplicationSubmittedDto> OnJobApplication(ApplyForJobCommand jobApplication)
        {
            logger.LogInformation("Applicant {Applicant} applies for {JobOffer} offer", jobApplication.ApplicantId, jobApplication.OfferId);

            var notification = new Notification();
            var newApplicationId = await jobService.Apply(jobApplication, notification);
            return new ApplicationSubmittedDto
            {
                Id = newApplicationId,
                Errors = notification.ErrorMessages.ToList()
            };
        }
    }

}
