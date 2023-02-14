using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IOfferRepository : IRepository<JobOffer>
    {
        public Task<PaginatedRecords<GetOffersDto>> GetOffers(GetOffersQuery query);
        public Task<GetOfferDto> GetOfferDetails(Guid id);
    }
}
