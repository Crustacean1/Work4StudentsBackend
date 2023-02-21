using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOfferDto>>
    {
        public string? Categories { get; set; } = "";

        public string? Keywords { get; set; } = "";

        public string? Mode { get; set; } = "";

        public string? Status { get; set; } = "";

        public Guid UserId { get; set; }
    }
}
