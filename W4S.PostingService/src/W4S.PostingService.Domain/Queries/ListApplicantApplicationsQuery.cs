namespace W4S.PostingService.Domain.Queries
{
    public class ListApplicantApplicationsQuery
    {
        public Guid ApplicantId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
