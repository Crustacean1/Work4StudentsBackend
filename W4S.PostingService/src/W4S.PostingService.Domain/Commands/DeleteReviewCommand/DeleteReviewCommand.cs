namespace W4S.PostingService.Domain.Commands
{
    public record DeleteReviewCommand
    {
        public Guid ReviewId { get; set; }
    }
}
