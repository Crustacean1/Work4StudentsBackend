namespace W4S.PostingService.Domain.Models
{
    public class Recruiter : Person
    {
        public Company Company { get; set; }

        public ICollection<JobOffer> Offers { get; set; }

        public Guid PostJobOffer(JobOffer offerInfo)
        {
            offerInfo.Id = Guid.NewGuid();
            offerInfo.Recruiter = this;
            offerInfo.Status = JobOffer.OfferStatus.Active;
            offerInfo.Address = Company.Address;

            Offers.Add(offerInfo);

            return offerInfo.Id;
        }
    }
}
