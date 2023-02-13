using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferCommand : IRequest
    {
        public UpdateOfferDto Offer { get; set; }

        public Guid OfferId { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
