using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersDto
    {
        public Guid Id { get; set; }

        public OfferStatus Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public Address Address { get; set; }

        public PayRange PayRange { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Schedule> WorkingHours { get; set; } = new List<Schedule>();
    }
}
