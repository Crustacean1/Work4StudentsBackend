namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentApplicationsQuery : PaginatedQuery
    {
        public GetStudentApplicationsQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid StudentId { get; set; }
    }
}
