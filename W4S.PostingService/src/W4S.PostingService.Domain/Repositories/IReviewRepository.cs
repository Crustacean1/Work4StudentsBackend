using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IReviewRepository<TEntity> : IRepository<TEntity> where TEntity : Review
    {
        Task<PaginatedRecords<TEntity>> GetSubmittedReviews(Guid authorId, PaginatedQuery query);

        Task<PaginatedRecords<TEntity>> GetReceivedReviews(Guid subjectid, PaginatedQuery query);

        Task<PaginatedRecords<TEntity>> GetDirectReviews(Guid subjectId, PaginatedQuery query);

        Task<decimal> GetRatingAverage(Guid subjectId);
    }
}
