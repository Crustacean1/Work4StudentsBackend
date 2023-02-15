using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Application : Entity
    {
        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        public JobOffer Offer { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public decimal WorkTimeOverlap { get; set; }

        public double Distance { get; set; }

        public DateTime LastChanged { get; set; }

        public ApplicationStatus Status { get; set; }

        public string Message { get; set; }

        public ApplicationReview? Review { get; set; }
    }
}
