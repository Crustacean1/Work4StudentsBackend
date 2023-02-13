using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Domain.Queries
{
    public class PaginatedQuery
    {
        private int pageSize;
        private int page;

        const int MAX_PAGE_SIZE = 100;

        public PaginatedQuery() { }

        public PaginatedQuery(int page, int pageSize)
        {
            Page = Math.Max(page, 1);
            PageSize = pageSize;
        }

        public int Page
        {
            get { return page; }
            set
            {
                page = Math.Max(1, value);
            }
        }

        public int PageSize
        {
            get { return pageSize; }

            set
            {
                pageSize = Math.Min(Math.Max(value, 1), MAX_PAGE_SIZE);
            }
        }
    }
}
