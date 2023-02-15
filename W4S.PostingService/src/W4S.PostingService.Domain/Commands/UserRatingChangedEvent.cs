namespace W4S.PostingService.Domain.Commands
{
    public class UserRatingChangedEvent
    {
        public Guid UserId { get; set; }

        public decimal Rating { get; set; }
    }
}
