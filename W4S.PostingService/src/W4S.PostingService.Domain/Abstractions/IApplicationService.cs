using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Abstractions
{
    public interface IApplicationService
    {
        public Task<Guid> Submit(ApplyForJobCommand applyCommand, Notification notification);

        public Task Accept(AcceptApplicationDto acceptCommand, Notification notification);

        public Task<IEnumerable<Application>> GetOfferApplications(Guid offerId, int page, int pageSize, Notification notification);

        public Task<IEnumerable<Application>> GetApplicantApplications(Guid applicantId, int page, int pageSize, Notification notification);
    }
}
