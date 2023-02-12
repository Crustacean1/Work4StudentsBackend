namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQuery : PaginatedQuery
    {
        public GetOffersQuery(int page, int pageSize) : base(page, pageSize) { }
    }
}
