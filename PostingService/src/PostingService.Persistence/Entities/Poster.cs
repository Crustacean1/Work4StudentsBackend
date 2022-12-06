using System;

namespace PostingService.Persistence.Entities
{
    public class Poster
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }

        public string About { get; set; }

        public decimal Rating { get; set; }
    }
}
