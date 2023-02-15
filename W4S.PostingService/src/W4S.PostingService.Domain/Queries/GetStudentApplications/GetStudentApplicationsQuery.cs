using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<GetApplicationDto>>
    {
        public Guid StudentId { get; set; }
    }
}
