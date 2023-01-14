using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.Commands;
using AutoMapper;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Domain.Abstractions;

namespace W4S.PostingService.Domain.Services
{
    public class JobService : IJobService
    {
        private readonly ILogger<JobService> logger;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IRepository<Applicant> applicantRepository;
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IMapper mapper;

        public JobService(ILogger<JobService> logger,
                          IRepository<JobOffer> offerRepository,
                          IRepository<Applicant> applicantRepository,
                          IRepository<Recruiter> recruiterRepository,
                          IRepository<Application> applicationRepository)
        {
            this.logger = logger;
            this.offerRepository = offerRepository;
            this.applicantRepository = applicantRepository;
            this.recruiterRepository = recruiterRepository;
            this.applicationRepository = applicationRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobOffer, PostJobOfferCommand>());
            mapper = config.CreateMapper();
        }

        public async Task<Guid> PostJobOffer(PostJobOfferCommand postJobOffer, Notification notification)
        {
            logger.LogInformation("Creating new job offer");

            var recruiter = await recruiterRepository.GetEntityAsync(postJobOffer.RecruiterId);

            if (recruiter is null)
            {
                notification.AddError($"JobOffer needs to be created by recruiter, no recruiter with id: {postJobOffer.RecruiterId}");
                return Guid.Empty;
            }

            var newOfferId = recruiter.PostJobOffer(mapper.Map<JobOffer>(postJobOffer));

            await recruiterRepository.SaveAsync();

            return newOfferId;
        }

        public async Task<Guid> Apply(ApplyForJobCommand jobApplication, Notification notification)
        {
            logger.LogInformation("Creating application of user {ApplicantId} to job with id: {OfferId}", jobApplication.ApplicantId, jobApplication.OfferId);

            var applicant = await applicantRepository.GetEntityAsync(jobApplication.ApplicantId);
            var jobOffer = await offerRepository.GetEntityAsync(jobApplication.OfferId);

            if (applicant is null)
            {
                notification.AddError("Applicant could not be found");
            }
            if (jobOffer is null)
            {
                notification.AddError("Job offer could not be found");
            }

            if (!notification.HasErrors)
            {
                var id = applicant!.SubmitApplication(jobOffer!, notification);

                await applicantRepository.SaveAsync();

                return id;
            }
            return Guid.Empty;
        }

        public async Task WithdrawApplication(Guid applicationId, Notification notification)
        {
            var application = await applicationRepository.GetEntityAsync(applicationId);

            if (application is not null)
            {
                application.Withdraw(notification);
                if (!notification.HasErrors)
                {
                    await applicationRepository.SaveAsync();
                }
            }
            else
            {
                notification.AddError($"Cannot withdraw application with id {applicationId}, application doesn't exist");
            }
        }
    }
}
