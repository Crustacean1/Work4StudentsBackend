namespace W4S.PostingService.Domain.Entities
{
    public class OfferReview : Review
    {
        public JobOffer Offer { get; set; }
    }
}
