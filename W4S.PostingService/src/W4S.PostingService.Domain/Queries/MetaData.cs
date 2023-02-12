namespace W4S.PostingService.Domain.Queries
{
    public class MetaData
    {
        public int TotalCount { get; set; }
        public int PageCount => (TotalCount + PageSize - 1) / PageSize;
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
