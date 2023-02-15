using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferQuery : IRequest<GetOfferDetailsDto>
    {
        public Guid OfferId { get; set; }

        public Guid UserId { get; set; }
    }
}
