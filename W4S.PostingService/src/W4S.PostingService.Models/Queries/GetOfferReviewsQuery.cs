using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetOfferReviewsQuery : PaginatedQuery, IRequest<PaginatedList<OfferReviewDto>>
    {
        public Guid OfferId { get; set; }
    }
}
