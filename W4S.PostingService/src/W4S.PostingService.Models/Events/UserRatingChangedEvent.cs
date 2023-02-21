namespace W4S.PostingService.Models.Events
{
    public class UserRatingChangedEvent
    {
        public Guid UserId { get; set; }

        public decimal Rating { get; set; }
    }
}
