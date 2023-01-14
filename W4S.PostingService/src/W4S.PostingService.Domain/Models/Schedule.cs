namespace W4S.PostingService.Domain.Models
{
    public record DailySchedule
    {
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public record Schedule
    {
        public DailySchedule Monday { get; set; }

        public DailySchedule Tuesday { get; set; }

        public DailySchedule Wednesday { get; set; }

        public DailySchedule Thursday { get; set; }

        public DailySchedule Friday { get; set; }

        public DailySchedule Saturday { get; set; }

        public DailySchedule Sunday { get; set; }
    }
}
