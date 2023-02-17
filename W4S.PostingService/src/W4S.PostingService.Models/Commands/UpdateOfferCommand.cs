using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Commands
{
    public class UpdateOfferCommand : IRequest<Guid>
    {
        public UpdateOfferDto Offer { get; set; }

        public Guid OfferId { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
