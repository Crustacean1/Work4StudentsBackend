namespace PostingService.Domain.Models
{
    public class JobApplication
    {
        public JobOffer Offer { get; set; }

        public JobApplicant Applicant { get; set; }
    }
}
