namespace W4S.Common
{
    public class MetaData
    {
        public int TotalCount { get; set; }
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
