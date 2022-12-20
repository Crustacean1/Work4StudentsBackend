namespace PostingService.Persistence.Entities
{
    public class Application
    {
        public Guid Id { get; set; }

        public Applicant JobApplicant { get; set; }

        public JobOffer JobOffer { get; set; }

        public DateTime DateOfApplication { get; set; }

        public decimal ScheduleCoverage { get; set; }

        public bool LocationOverlaps { get; set; }
    }
}
