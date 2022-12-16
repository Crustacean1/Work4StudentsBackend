using PostingService.Persistence.Entities;

namespace PostingService.Persistence
{
    public interface IJobOfferRepository
    {
        public void AddJobOffer(JobOffer jobOffer);

        public void UpdateJobOffer(JobOffer jobOffer);

        public void DeleteJobOffer(Guid id);

        public JobOffer GetJobOffer(Guid Id);

        public IEnumerable<JobOffer> GetJobOffers(Func<JobOffer, bool> selector);
    }
}
