using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<Application>>
    {
        public GetStudentApplicationsQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid StudentId { get; set; }
    }
}
