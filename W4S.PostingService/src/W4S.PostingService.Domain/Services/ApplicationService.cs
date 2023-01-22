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

        public ApplicationService(IRepository<Application> applicationRepository, IRepository<JobOffer> offerRepository, IRepository<Applicant> applicantRepository)
        {
            this.applicationRepository = applicationRepository;
            this.offerRepository = offerRepository;
            this.applicantRepository = applicantRepository;
        }

        public async Task<Guid> Submit(ApplyForJobCommand applyCommand, Notification notification)
        {
            var offer = await offerRepository.GetEntityAsync(applyCommand.OfferId);
            var applicant = await applicantRepository.GetEntityAsync(applyCommand.ApplicantId);
            if (offer is null)
            {
                notification.AddError($"No job offer with id: {applyCommand.OfferId}");
            }
            if (applicant is null)
            {
                notification.AddError($"No applicant with id: {applyCommand.ApplicantId}");
            }

            if (notification.HasErrors)
            {
                return Guid.Empty;
            }

            var application = new Application { Offer = offer!, Applicant = applicant! };

            application.Submit(notification);

            if (!notification.HasErrors)
            {
                await applicationRepository.AddAsync(application);
                await applicationRepository.SaveAsync();
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
            var applications = await applicationRepository.GetEntitiesAsync(page, pageSize, application => application.OfferId == offerId);
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
