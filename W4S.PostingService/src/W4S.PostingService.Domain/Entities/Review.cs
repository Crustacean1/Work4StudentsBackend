namespace W4S.PostingService.Domain.Entities
{
    public class Review
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public Guid AuthorId { get; set; }
    }
}
