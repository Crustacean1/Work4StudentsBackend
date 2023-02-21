using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Application : Entity
    {
        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        public JobOffer Offer { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public double WorkTimeOverlap { get; set; }

        public double Distance { get; set; }

        public DateTime LastChanged { get; set; }

        public ApplicationStatus Status { get; set; }

        public string Message { get; set; }

        public ApplicationReview? Review { get; set; }

        public void ComputeDistance()
        {
            if (Student.Address.Latitude is null || Student.Address.Longitude is null) { return; }
            if (Offer.Address.Latitude is null || Offer.Address.Longitude is null) { return; }

            var lonDelta = (Math.PI * (Student.Address.Longitude - Offer.Address.Longitude) / 180) ?? 0;
            var latDelta = (Math.PI * (Student.Address.Latitude - Offer.Address.Latitude) / 180) ?? 0;

            var latA = (Math.PI * (Student.Address.Latitude / 180.0)) ?? 0;
            var latB = (Math.PI * (Offer.Address.Latitude / 180.0)) ?? 0;


            var a = Math.Pow(Math.Sin(latDelta / 2), 2) + (Math.Cos(latA) * Math.Cos(latB) * Math.Pow(Math.Sin(lonDelta / 2), 2));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = 6371 * c;
            Distance = d;
        }
    }
}
