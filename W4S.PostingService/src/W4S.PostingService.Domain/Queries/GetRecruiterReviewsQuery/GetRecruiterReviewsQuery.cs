using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQuery : PaginatedQuery
    {
        public Guid RecruiterId { get; set; }
    }
}
