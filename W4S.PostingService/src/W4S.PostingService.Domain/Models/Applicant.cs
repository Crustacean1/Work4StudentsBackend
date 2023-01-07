using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Models
{
    public class Applicant : Person
    {
        public string Location { get; set; }

        public Schedule WorkingHours { get; set; }

        public Guid SubmitApplication(JobOffer offer, Notification notification)
        {
            return offer.Apply(this, notification);
        }
    }
}
