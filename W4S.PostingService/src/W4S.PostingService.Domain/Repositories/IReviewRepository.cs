using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {

        Task<IEnumerable<Review>> GetRecruiterSubmittedReviews(Guid recruiterId, int page, int pageSize);

        Task<int> GetRecruiterSubmittedReviewCount(Guid recruiterId);

        Task<IEnumerable<Review>> GetStudentSubmittedReviews(Guid studentId, int page, int pageSize);

        Task<int> GetStudentSubmittedReviewCount(Guid studentId);

        Task<IEnumerable<Review>> GetRecruiterReviews(Guid recruiterId, int page, int pageSize);

        Task<int> GetRecruiterReviewCount(Guid recruiterId);

        Task<IEnumerable<Review>> GetStudentReviews(Guid studentId, int page, int pageSize);

        Task<int> GetStudentReviewCount(Guid studentId);
    }
}
