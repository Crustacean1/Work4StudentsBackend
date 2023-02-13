using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Student : Person
    {
        public Address Address { get; set; }

        public IEnumerable<Schedule> Availability { get; set; } = new List<Schedule>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public ICollection<Review> ReceivedReviews { get; set; } = new List<Review>();

        public ICollection<Review> SubmittedReviews { get; set; } = new List<Review>();
    }
}
