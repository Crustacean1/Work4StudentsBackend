using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferQueryHandler
    {
        private readonly IRepository<JobOffer> offerRepository;

        public GetOfferQueryHandler(IRepository<JobOffer> offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<JobOffer> HandleQuery(GetOfferQuery query)
        {
            var offer = await offerRepository.GetEntityAsync(query.OfferId);

            if (offer is null)
            {
                throw new PostingException($"No job offer with id: {query.OfferId}");
            }

            return offer;
        }
    }
}
