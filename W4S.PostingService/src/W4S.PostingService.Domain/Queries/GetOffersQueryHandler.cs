using MediatR;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, PaginatedList<GetOfferDto>>
    {
        private readonly IOfferRepository offerRepository;

        public GetOffersQueryHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<PaginatedList<GetOfferDto>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await offerRepository.GetOffers(request);

            return new PaginatedList<GetOfferDto>(offers.Items.ToList(), request.Page, request.PageSize, offers.TotalCount);
        }
    }
}
