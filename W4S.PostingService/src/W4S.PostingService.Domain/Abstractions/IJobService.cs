using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Abstractions
{
    public interface IJobService
    {
        Task<Guid> PostJobOffer(PostJobOfferCommand postOfferCommand, Notification notification);
        Task<IEnumerable<JobOffer>> ListJobOffers(JobOffersQuery query);
        Task ArchiveOffer(ArchiveJobOfferCommand archiveCommand);
    }
}
