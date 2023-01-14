namespace W4S.PostingService.Domain.Models
{
    public record Schedule
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
