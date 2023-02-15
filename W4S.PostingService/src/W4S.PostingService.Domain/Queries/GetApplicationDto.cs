namespace W4S.PostingService.Domain.Queries
{
    public class GetApplicationDto
    {
        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        public Guid StudentId { get; set; }

        public double WorkTimeOverlap { get; set; }

        public double Distance { get; set; }

        public DateTime LastChanged { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }

        public ApplicationOfferDto Offer { get; set; }
    }
}
