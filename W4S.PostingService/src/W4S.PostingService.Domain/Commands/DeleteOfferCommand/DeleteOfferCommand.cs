using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record DeleteOfferCommand : IRequest<Guid>
    {
        public Guid OfferId { get; set; }
    }
}
