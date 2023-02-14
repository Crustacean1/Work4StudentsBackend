using System.ComponentModel.DataAnnotations;

namespace W4S.PostingService.Domain.Queries
{
    public class PaginatedQuery
    {
        const int MAX_PAGE_SIZE = 100;

        public PaginatedQuery() { }

        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        [Range(1, MAX_PAGE_SIZE)]
        public int PageSize { get; set; }

        public int RecordsToSkip => (Page - 1) * PageSize;
    }
}
