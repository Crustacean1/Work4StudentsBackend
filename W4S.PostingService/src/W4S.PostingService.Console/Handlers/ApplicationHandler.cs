using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Responses;
using W4S.PostingService.Domain.ValueType;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("application")]
    public class ApplicationHandler
    {
        private readonly ILogger<ApplicationHandler> logger;
        private readonly IApplicationService applicationService;

        public ApplicationHandler(ILogger<ApplicationHandler> logger, IApplicationService applicationService)
        {
            this.logger = logger;
            this.applicationService = applicationService;
        }

        [BusRequestHandler("apply")]
        public async Task<ApplicationSubmittedDto> OnJobApplication(ApplyForJobCommand jobApplication)
        {
            logger.LogInformation("Applicant {Applicant} applies for {JobOffer} offer", jobApplication.ApplicantId, jobApplication.OfferId);

            Notification notification = new();
            var newApplicationId = await applicationService.Submit(jobApplication, notification);

            return new ApplicationSubmittedDto
            {
                Id = newApplicationId,
                Errors = notification.ErrorMessages.ToList()
            };
        }

        [BusRequestHandler("accept")]
        public async Task<ApplicationAcceptedDto> OnApplicationAccepted(AcceptApplicationDto acceptDto)
        {
            logger.LogInformation("Recruiter {Recruiter} accepts application {Application}", acceptDto.RecruiterId, acceptDto.ApplicationId);

            Notification notification = new();
            applicationService.Accept(acceptDto, notification);
            return new ApplicationAcceptedDto();
        }

        [BusRequestHandler("list.offer")]
        public async Task<ApplicationListResponse> OnJobApplicationList(ListOfferApplicationsQuery listQuery)
        {
            logger.LogInformation("Lising applications for job {Job}", listQuery.OfferId);
            Notification notification = new();

            return new ApplicationListResponse
            {
                Applications = (await applicationService.GetOfferApplications(listQuery.OfferId,
                                                                              listQuery.Page,
                                                                              listQuery.PageSize,
                                                                              notification)).ToList()
            };
        }

        [BusRequestHandler("list.applicant")]
        public async Task<ApplicationListResponse> OnApplicantApplicationList(ListApplicantApplicationsQuery listQuery)
        {
            logger.LogInformation("Lising applications for job {Job}", listQuery.ApplicantId);
            Notification notification = new();

            return new ApplicationListResponse
            {
                Applications = (await applicationService.GetApplicantApplications(listQuery.ApplicantId,
                                                                                  listQuery.Page,
                                                                                  listQuery.PageSize,
                                                                                  notification)).ToList()
            };
        }
    }
}
