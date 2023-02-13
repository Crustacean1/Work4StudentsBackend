using W4S.PostingService.Domain.Queries;

namespace W4S.Gateway.Console.Posting
{
    public class OfferQuery : PaginatedQuery
    {
        public string? Categories { get; set; }

        public string? Keywords { get; set; }
    }
}
