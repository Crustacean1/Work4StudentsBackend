namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentReviewsQuery : PaginatedQuery
    {
        public Guid StudentId { get; set; }
    }
}
