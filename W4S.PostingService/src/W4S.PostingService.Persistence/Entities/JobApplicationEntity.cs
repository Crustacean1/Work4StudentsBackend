namespace PostingService.Persistence.Entities
{
    public class ApplicationEntity
    {
        public Guid Id { get; set; }

        public ApplicantEntity JobApplicant { get; set; }

        public JobOfferEntity JobOffer { get; set; }

        public DateTime DateOfApplication { get; set; }

        public decimal ScheduleCoverage { get; set; }

        public bool LocationOverlaps { get; set; }
    }
}
