using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetOfferQuery : IRequest<GetOfferDetailsDto>
    {
        public Guid OfferId { get; set; }

        public Guid UserId { get; set; }
    }
}
