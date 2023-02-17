using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Commands
{
    public record PostOfferCommand : IRequest<Guid>
    {
        public PostOfferDto Offer { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
