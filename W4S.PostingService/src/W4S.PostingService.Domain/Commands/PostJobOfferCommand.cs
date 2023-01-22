using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class PostJobOfferCommand
    {
        public Guid RecruiterId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public Address Address { get; set; }

        public uint Openings { get; set; }

        public PayRange PayRange { get; set; }

        public IEnumerable<Schedule> WorkingHours { get; set; }
    }
}
