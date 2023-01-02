using System.Collections.Generic;
using System;

namespace PostingService.Persistence.Entities
{
    public class ApplicantEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }
    }
}
