using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Domain.Queries
{
    public class PaginatedQuery
    {
        const int MAX_PAGE_SIZE = 100;

        public PaginatedQuery() { }

        public PaginatedQuery(int page, int pageSize)
        {
            if (pageSize > MAX_PAGE_SIZE && pageSize < 0)
            {
                throw new PostingException($"Invalid page size, page size must range from 0 to {MAX_PAGE_SIZE}", 400);
            }
            PageSize = pageSize;
            Page = page;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
