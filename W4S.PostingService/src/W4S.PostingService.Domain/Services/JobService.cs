using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.Commands;
using AutoMapper;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Entities;

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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostJobOfferCommand, JobOffer>());
            mapper = config.CreateMapper();
        }

        public async Task<Guid> PostJobOffer(PostJobOfferCommand postOfferCommand, Notification notification)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(postOfferCommand.RecruiterId);

            if (recruiter is null)
            {
                notification.AddError($"JobOffer needs to be created by recruiter, no recruiter with id: {postOfferCommand.RecruiterId}");
                return Guid.Empty;
            }

            var offer = mapper.Map<JobOffer>(postOfferCommand);
            offer.Id = Guid.NewGuid();
            offer.Recruiter = recruiter;
            await offerRepository.AddAsync(offer);

            logger.LogInformation("So far so good");
            try
            {
                await offerRepository.SaveAsync();
            }
            catch (Exception e)
            {
                logger.LogError("Error: {Error} {Inner} {StackTrace}", e.Message, e.InnerException?.Message ?? "None", e.StackTrace);
            }
            logger.LogInformation("Even better");

            return offer.Id;
        }

        public async Task<IEnumerable<JobOffer>> ListJobOffers(JobOffersQuery query)
        {
            return await offerRepository.GetEntitiesAsync(query.Page, query.PageSize);
        }

        public async Task<Guid> Apply(Guid applicantId, Guid jobOfferId, string message, Notification notification)
        {
            logger.LogInformation("Creating application of user {ApplicantId} for job with id: {OfferId}", applicantId, jobOfferId);

            var applicant = await applicantRepository.GetEntityAsync(applicantId);
            var jobOffer = await offerRepository.GetEntityAsync(jobOfferId);

            var application = new Application { Applicant = applicant, Offer = jobOffer, Message = message };
            application.Submit(notification);

            if (!notification.HasErrors)
            {
                await applicationRepository.AddAsync(application);
                await applicationRepository.SaveAsync();
                return application.Id;
            }

            return Guid.Empty;
        }

        /*public async Task WithdrawApplication(Guid applicationId, Notification notification)
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
        }*/

        public async Task ArchiveOffer(ArchiveJobOfferCommand archiveCommand)
        {
            JobOffer offer = await offerRepository.GetEntityAsync(archiveCommand.OfferId) ?? throw new InvalidOperationException($"Could not archive {archiveCommand.OfferId}");
            offer.Status = JobOffer.OfferStatus.Archived;
            await offerRepository.SaveAsync();
        }
    }
}
