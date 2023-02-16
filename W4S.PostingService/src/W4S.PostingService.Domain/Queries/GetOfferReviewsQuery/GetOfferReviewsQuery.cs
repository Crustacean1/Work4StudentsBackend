using MediatR;
using W4S.PostingService.Domain.Dto;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferReviewsQuery : PaginatedQuery, IRequest<PaginatedList<OfferReviewDto>>
    {
        public Guid OfferId { get; set; }
    }
}
