using W4S.PostingService.Domain.Models;

namespace W4S.PostingService.Domain.Commands
{
    public class CreateJobOffer
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public uint Openings { get; set; }

        public PayRange PayRange { get; set; }

        public Schedule WorkingHours { get; set; }
    }
}
