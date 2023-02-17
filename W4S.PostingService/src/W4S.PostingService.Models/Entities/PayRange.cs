namespace W4S.PostingService.Models.Entities
{
    public record PayRange
    {
        public decimal Min { get; init; }

        public decimal Max { get; init; }
    }
}
