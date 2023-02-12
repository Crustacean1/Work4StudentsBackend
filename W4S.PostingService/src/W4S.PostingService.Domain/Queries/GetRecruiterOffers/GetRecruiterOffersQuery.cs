namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQuery : PaginatedQuery
    {
        public GetRecruiterOffersQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid RecrutierId { get; set; }
    }
}
