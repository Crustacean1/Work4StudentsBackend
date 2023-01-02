using System.Collections.Generic;
using System;

namespace PostingService.Persistence.Entities
{
    public class JobOfferEntity
    {
        public Guid Id { get; set; }

        public RecruiterEntity Poster { get; set; }

        public IEnumerable<ApplicationEntity> Applications { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public string Location { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }
    }
}
