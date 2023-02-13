using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentReviewsQuery : PaginatedQuery, IRequest<PaginatedList<ApplicationReview>>
    {
        public Guid StudentId { get; set; }
    }
}
