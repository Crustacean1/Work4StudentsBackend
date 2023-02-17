using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetStudentReviewsQuery : PaginatedQuery, IRequest<PaginatedList<ApplicationReviewDto>>
    {
        public Guid StudentId { get; set; }
    }
}
