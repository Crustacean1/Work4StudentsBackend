namespace W4S.PostingService.Domain.Models
{
    public record Address
    {
        public string Country { get; init; }

        public string Region { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string Building { get; init; }
    }
}
