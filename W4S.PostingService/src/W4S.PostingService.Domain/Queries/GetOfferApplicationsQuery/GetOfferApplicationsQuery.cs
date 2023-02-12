namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQuery : PaginatedQuery
    {
        public GetOfferApplicationsQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid OfferId { get; set; }
    }
}
