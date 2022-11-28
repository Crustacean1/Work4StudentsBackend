using System.Collections.Generic;
using System;

namespace PostingService.Persistence.Entities
{
    public class Posting
    {
        public long Id { get; set; }

        public Poster Poster { get; set; }

        public IEnumerable<Applicant> Applicants { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public string MinSalary { get; set; }

        public string MaxSalary { get; set; }

        public string Location { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }
    }
}
