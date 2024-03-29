using System.Linq.Expressions;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        public Task SaveAsync();

        public Task AddAsync(TEntity entity);

        public void Delete(Guid id);

        public Task<TEntity> RequireEntityAsync(Guid id);

        public Task<TEntity?> GetEntityAsync(Guid id);

        public Task<TEntity?> GetEntityAsync(Expression<Func<TEntity, bool>> selector);

        public Task<IEnumerable<TEntity>> GetEntitiesAsync(int page, int pageSize, Expression<Func<TEntity, bool>> selector, Expression<Func<TEntity, object>> comparator);

        public Task<IEnumerable<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>> selector);

        public Task<int> GetTotalCount(Expression<Func<TEntity, bool>> selector);
    }
}
