using W4S.PostingService.Models.Entities;

namespace W4S.PostingService.Models.Transfer
{
    public class PostOfferDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public Address Address { get; set; }

        public PayRange PayRange { get; set; }

        public ICollection<Schedule> WorkingHours { get; set; } = new List<Schedule>();
    }
}
