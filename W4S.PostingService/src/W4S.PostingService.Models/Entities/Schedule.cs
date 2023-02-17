namespace W4S.PostingService.Models.Entities
{
    public record Schedule
    {
        public int DayOfWeek { get; set; }

        public int StartHour { get; set; }

        public int Duration { get; set; }
    }
}
