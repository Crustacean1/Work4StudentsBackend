using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Commands
{
    public class GetOfferReviewsQuery : PaginatedQuery
    {
        public Guid OfferId { get; set; }
    }
}
