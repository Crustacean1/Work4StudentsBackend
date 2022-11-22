using PostingService.Persistence.Entities;

namespace PostingService.Persistence
{
    public interface IPostingRepository
    {
        public IEnumerable<Applicant> GetAllApplicants(uint page, uint itemsPerPage);

        public IEnumerable<Posting> GetPostings(uint page, uint itemsPerPage);

        public IEnumerable<Poster> GetPosters(uint page, uint itemsPerPage);

        public IEnumerable<Application> GetApplications(Posting posting, uint page, uint itemsPerPage);
    }

}
