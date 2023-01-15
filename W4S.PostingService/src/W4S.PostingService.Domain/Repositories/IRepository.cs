using System.Linq.Expressions;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        public Task SaveAsync();

        public Task DeleteAsync(Guid id);

        public Task<TEntity?> GetEntityAsync(Guid id);

        public Task<IEnumerable<TEntity>> GetEntitiesAsync(int pageSize, int pageSkip, Expression<Func<TEntity, TEntity, bool>> comparator);

        public Task<IEnumerable<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>> selector);
    }
}
