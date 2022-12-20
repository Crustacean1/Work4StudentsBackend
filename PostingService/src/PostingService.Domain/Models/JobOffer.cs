namespace PostingService.Domain.Models
{
    public class JobOffer
    {
        public uint Id { get; set; }

        public uint RecruiterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Position { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public string Location { get; set; }

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }

        public IEnumerable<JobApplication> Applications { get; set; }
    }
}
