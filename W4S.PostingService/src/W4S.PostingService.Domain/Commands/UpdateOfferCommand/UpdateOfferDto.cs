using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Role { get; set; }

        public Address? Address { get; set; }

        public PayRange? PayRange { get; set; }

        public ICollection<Schedule>? WorkingHours { get; set; } = new List<Schedule>();
    }
}
