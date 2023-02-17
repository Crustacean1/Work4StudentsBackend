using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace W4S.PostingService.Models.Queries
{
    public class PaginatedQuery
    {
        private const int MAX_PAGE_SIZE = 100;

        public PaginatedQuery() { }

        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        [Range(1, MAX_PAGE_SIZE)]
        public int PageSize { get; set; }

        [IgnoreDataMember]
        public int RecordsToSkip => (Page - 1) * PageSize;
    }
}
