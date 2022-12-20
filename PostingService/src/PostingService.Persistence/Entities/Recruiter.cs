using System;

namespace PostingService.Persistence.Entities
{
    public class Recruiter
    {
        public Guid Id { get; set; }

        public Company Company { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Rating { get; set; }
    }
}
