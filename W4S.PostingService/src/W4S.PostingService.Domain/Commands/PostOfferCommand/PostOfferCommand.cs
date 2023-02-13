using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public record PostOfferCommand : IRequest<Guid>
    {
        public PostOfferDto Offer { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
