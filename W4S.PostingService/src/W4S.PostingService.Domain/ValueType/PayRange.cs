namespace W4S.PostingService.Domain.Models
{
    public record PayRange
    {
        public decimal Min { get; init; }

        public decimal Max { get; init; }
    }
}
