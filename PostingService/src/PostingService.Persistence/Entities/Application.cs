using System;

namespace PostingService.Persistence.Entities
{
    public class Application
    {
        public Applicant JobApplicant { get; set; }

        public Posting JobPosting { get; set; }

        public DateTime DateOfApplication { get; set; }

        public decimal ScheduleCoverage { get; set; }

        public bool LocationOverlap { get; set; }
    }
}
