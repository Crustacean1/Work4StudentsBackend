namespace W4S.PostingService.Domain.Entities
{
    public class OfferReviewDto : Entity
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
