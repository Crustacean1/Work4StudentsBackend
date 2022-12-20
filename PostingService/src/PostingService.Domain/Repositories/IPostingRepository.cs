using PostingService.Domain.Models;

namespace PostingService.Domain.Repositories
{
    public interface IJobOfferRepository
    {
        public void AddJobOffer(JobOffer jobOffer);

        public void UpdateJobOffer(JobOffer jobOffer);

        public void DeleteJobOffer(uint id);

        public JobOffer GetJobOffer(uint Id);

        public IEnumerable<JobOffer> GetJobOffers();
    }
}
