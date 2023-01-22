using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4s.PostingService.Domain.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IRepository<Applicant> applicantRepository;

        private readonly ILogger<ApplicationService> logger;

        public ApplicationService(IRepository<Application> applicationRepository, IRepository<JobOffer> offerRepository, IRepository<Applicant> applicantRepository, ILogger<ApplicationService> logger)
        {
            this.applicationRepository = applicationRepository;
            this.offerRepository = offerRepository;
            this.applicantRepository = applicantRepository;
            this.logger = logger;
        }

        public async Task<Guid> Submit(ApplyForJobCommand applyCommand, Notification notification)
        {
            var offer = await offerRepository.GetEntityAsync(applyCommand.OfferId);
            var applicant = await applicantRepository.GetEntityAsync(applyCommand.ApplicantId);

            var application = new Application { OfferId = offer.Id, ApplicantId = applicant.Id, Message = "" };

            application.Submit(notification);

            if (!notification.HasErrors)
            {
                try
                {

                    await applicationRepository.AddAsync(application);
                    await applicationRepository.SaveAsync();
                    return application.Id;
                }
                catch (Exception e)
                {
                    logger.LogError("Error {Error} {InnerError}", e.Message, e.InnerException?.Message ?? "<none>");
                }
            }

            return Guid.Empty;
        }

        public async Task Accept(AcceptApplicationDto acceptCommand, Notification notification)
        {
            var application = await applicationRepository.GetEntityAsync(acceptCommand.ApplicationId);
            if (application is null)
            {
                notification.AddError($"No application found: {acceptCommand.ApplicationId}");
                return;
            }

            application.Accept(notification);
            if (!notification.HasErrors)
            {
                await applicationRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<Application>> GetOfferApplications(Guid offerId, int page, int pageSize, Notification notification)
        {
            var offer = await offerRepository.GetEntityAsync(offerId);
            if (offer is null)
            {
                notification.AddError($"No offer with id: {offerId}");
            }
            var applications = (await applicationRepository.GetEntitiesAsync(page, pageSize, application => application.OfferId == offerId)).ToList();
            logger.LogInformation("Heads up: {Count}", applications.Count());
            return applications;
        }

        public async Task<IEnumerable<Application>> GetApplicantApplications(Guid applicantId, int page, int pageSize, Notification notification)
        {
            var offer = await applicantRepository.GetEntityAsync(applicantId);
            if (offer is null)
            {
                notification.AddError($"No applicant with id: {applicantId}");
            }
            var applications = await applicationRepository.GetEntitiesAsync(page, pageSize, application => application.OfferId == applicantId);
            return applications;
        }
    }
}
