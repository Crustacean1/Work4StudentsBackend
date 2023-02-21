namespace W4S.PostingService.Models.Transfer
{
    public record OfferReviewDto
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public Guid OfferId { get; set; }

        public Guid StudentId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
