using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQuery : PaginatedQuery, IRequest<PaginatedList<Review>>
    {
        public Guid RecruiterId { get; set; }
    }
}
