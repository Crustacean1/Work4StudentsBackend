using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetStudentApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<GetApplicationDto>>
    {
        public Guid StudentId { get; set; }
    }
}
