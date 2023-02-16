using W4S.PostingService.Domain.Models;

namespace W4S.PostingService.Domain.Entities
{
    public class Student : Person
    {
        public IEnumerable<Schedule> Availability { get; set; } = new List<Schedule>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public ICollection<ApplicationReview> ReceivedReviews { get; set; } = new List<ApplicationReview>();

        public ICollection<ApplicationReview> SubmittedReviews { get; set; } = new List<ApplicationReview>();
    }
}
