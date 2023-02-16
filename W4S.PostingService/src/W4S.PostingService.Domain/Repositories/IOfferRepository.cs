using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IOfferRepository : IRepository<JobOffer>
    {
        public Task<PaginatedRecords<GetOfferDto>> GetOffers(GetOffersQuery query);
        public Task<PaginatedRecords<GetOfferDto>> GetRecruiterOffers(Guid recruiterId, PaginatedQuery query);
        public Task<GetOfferDetailsDto?> GetOfferDetails(Guid id, Guid userId);
    }
}
