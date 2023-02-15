using MediatR;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferQueryHandler : IRequestHandler<GetOfferQuery, GetOfferDto>
    {
        private readonly IOfferRepository offerRepository;

        public GetOfferQueryHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<GetOfferDto> Handle(GetOfferQuery query, CancellationToken cancellationToken)
        {
            var offer = await offerRepository.GetOfferDetails(query.OfferId);

            if (offer is null)
            {
                throw new PostingException($"No job offer with id: {query.OfferId}");
            }

            return offer;
        }
    }
}
