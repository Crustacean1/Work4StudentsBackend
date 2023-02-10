namespace W4S.Common
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> list, int totalCount, int pageSize, int currentPage)
        {
            AddRange(list);
            MetaData = new MetaData
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = currentPage
            };
        }
        public MetaData MetaData { get; set; }
    }
}
