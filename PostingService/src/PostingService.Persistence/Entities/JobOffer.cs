using System.Collections.Generic;
using System;

namespace PostingService.Persistence.Entities
{
    public class JobOffer
    {
        public Guid Id { get; set; }

        public Recruiter Poster { get; set; }

        public IEnumerable<Application> Applications { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public string Location { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }
    }
}
