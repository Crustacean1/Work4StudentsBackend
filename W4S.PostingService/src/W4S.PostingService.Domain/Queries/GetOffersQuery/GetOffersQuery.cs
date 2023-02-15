using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOfferDto>>
    {
        public string? Categories { get; set; } = "";

        public string? Keywords { get; set; } = "";

        public string? Mode { get; set; } = "";

        public string? Status { get; set; } = "";
    }
}
