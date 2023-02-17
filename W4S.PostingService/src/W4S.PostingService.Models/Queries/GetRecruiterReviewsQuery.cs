using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetRecruiterReviewsQuery : PaginatedQuery, IRequest<PaginatedList<OfferReviewDto>>
    {
        public Guid RecruiterId { get; set; }
    }
}
