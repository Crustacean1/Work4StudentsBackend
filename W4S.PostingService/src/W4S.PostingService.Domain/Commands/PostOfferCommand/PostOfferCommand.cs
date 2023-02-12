using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public class PostOfferCommand
    {
        public PostOfferDto Offer { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
