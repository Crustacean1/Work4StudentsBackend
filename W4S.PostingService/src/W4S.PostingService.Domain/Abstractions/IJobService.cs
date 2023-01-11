using W4S.PostingService.Domain.Commands;

namespace W4S.PostingService.Domain.Abstractions
{
    public interface IJobService
    {
        Task<Guid> PostJobOffer(PostJobOfferCommand command);
    }
}
