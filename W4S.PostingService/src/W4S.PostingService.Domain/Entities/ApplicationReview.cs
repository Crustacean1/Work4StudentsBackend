namespace W4S.PostingService.Domain.Entities
{
    public class ApplicationReview : Review
    {
        public Guid RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }

        public Guid ApplicationId { get; set; }

        public Application Application { get; set; }
    }
}
