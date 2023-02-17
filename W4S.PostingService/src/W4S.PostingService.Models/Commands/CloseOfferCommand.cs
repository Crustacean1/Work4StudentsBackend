using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record CloseOfferCommand : IRequest<Guid>
    {
        public Guid OfferId { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
