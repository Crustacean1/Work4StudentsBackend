namespace W4S.PostingService.Domain.Repositories
{
    public class PaginatedRecords<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
