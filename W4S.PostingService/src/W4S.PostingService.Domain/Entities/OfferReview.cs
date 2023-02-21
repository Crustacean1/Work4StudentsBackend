namespace W4S.PostingService.Domain.Entities
{
    public class OfferReview : Review
    {
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid OfferId { get; set; }

        public JobOffer Offer { get; set; }
    }
}
