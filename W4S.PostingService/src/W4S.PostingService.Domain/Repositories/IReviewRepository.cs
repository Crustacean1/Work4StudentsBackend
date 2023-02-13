using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IReviewRepository<TEntity> : IRepository<TEntity> where TEntity : Review
    {

        Task<IEnumerable<TEntity>> GetRecruiterSubmittedReviews(Guid recruiterId, int page, int pageSize);

        Task<int> GetRecruiterSubmittedReviewCount(Guid recruiterId);

        Task<IEnumerable<TEntity>> GetStudentSubmittedReviews(Guid studentId, int page, int pageSize);

        Task<int> GetStudentSubmittedReviewCount(Guid studentId);

        Task<IEnumerable<TEntity>> GetRecruiterReviews(Guid recruiterId, int page, int pageSize);

        Task<int> GetRecruiterReviewCount(Guid recruiterId);

        Task<IEnumerable<TEntity>> GetStudentReviews(Guid studentId, int page, int pageSize);

        Task<int> GetStudentReviewCount(Guid studentId);
    }
}
