namespace W4S.PostingService.Domain.ValueType
{
    public record Address
    {
        public string Country { get; init; }

        public string Region { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public string Building { get; init; }

        public Double? Latitude { get; set; } = 0;

        public Double? Longitude { get; set; } = 0;
    }
}
