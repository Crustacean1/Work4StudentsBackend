using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Abstractions
{
    public interface IJobService
    {
        Task<Guid> PostJobOffer(PostJobOfferCommand postJobOffer, Notification notification);
        Task<Guid> Apply(ApplyForJobCommand jobApplicant, Notification notification);
    }
}
