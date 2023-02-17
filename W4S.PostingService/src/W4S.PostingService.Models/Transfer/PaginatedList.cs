namespace W4S.PostingService.Models.Transfer
{
    public class PaginatedList<T>
    {
        public PaginatedList()
        {

        }

        public PaginatedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items.AddRange(items);
            MetaData = new MetaData
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                Page = page
            };
        }

        public List<T> Items { get; set; } = new List<T>();

        public MetaData MetaData { get; set; } = new MetaData();
    }
}
