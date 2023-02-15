using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

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
