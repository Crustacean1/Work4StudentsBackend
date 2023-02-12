using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferCommand
    {
        public UpdateOfferDto Offer { get; set; }

        public Guid OfferId { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
