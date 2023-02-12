using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewOfferCommand
    {
        public Guid OfferId { get; set; }

        public Guid StudentId { get; set; }

        public Review Review { get; set; }
    }
}