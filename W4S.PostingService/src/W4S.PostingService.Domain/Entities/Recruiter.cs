namespace W4S.PostingService.Domain.Entities
{
    public class Recruiter : Person
    {
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<JobOffer> Offers { get; set; } = new List<JobOffer>();

        public ICollection<Review> SubmitedReviews { get; set; } = new List<Review>();
    }
}
