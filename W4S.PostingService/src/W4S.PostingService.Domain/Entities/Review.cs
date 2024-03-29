namespace W4S.PostingService.Domain.Entities
{
    public class Review : Entity
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
