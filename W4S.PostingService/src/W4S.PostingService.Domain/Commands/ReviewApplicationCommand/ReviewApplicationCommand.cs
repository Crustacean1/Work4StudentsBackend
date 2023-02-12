using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewApplicationCommand
    {
        public Guid OfferId { get; set; }

        public Guid Recruitertd { get; set; }

        public Review Review { get; set; }
    }
}
