using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record DeleteOfferCommand : IRequest<Guid>
    {
        public Guid OfferId { get; set; }
    }
}
