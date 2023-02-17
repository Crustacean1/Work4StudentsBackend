using W4S.PostingService.Models.Entities;

namespace W4S.PostingService.Models.Transfer
{
    public class GetOfferDto
    {
        public Guid Id { get; set; }

        public string Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public string Mode { get; set; }

        public Address Address { get; set; }

        public PayRange PayRange { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Schedule> WorkingHours { get; set; } = new List<Schedule>();

        public CompanyDto Company { get; set; }
    }
}
