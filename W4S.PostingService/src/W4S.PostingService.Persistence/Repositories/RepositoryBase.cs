using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly PostingContext context;

        public RepositoryBase(PostingContext context)
        {
            this.context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(Guid id)
        {
            var entityToRemove = context.Set<T>().Single(e => e.Id == id);
            context.Remove(entityToRemove);
        }

        public virtual async Task<IEnumerable<T>> GetEntitiesAsync(int page, int pageSize, Expression<Func<T, bool>> selector, Expression<Func<T, object>> comparator)
        {
            var result = context.Set<T>()
                .Where(selector)
                .OrderBy(comparator)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return await result.ToListAsync();
        }

        public async Task<T> RequireEntityAsync(Guid id)
        {
            var result = await context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            if (result is null)
            {
                throw new InvalidOperationException($"No {typeof(T).Name} entity found with id: {id}");
            }
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetEntitiesAsync(Expression<Func<T, bool>> selector)
        {
            IEnumerable<T> result = await context.Set<T>().Where(selector).ToListAsync();
            return result;
        }

        public virtual async Task<T?> GetEntityAsync(Guid id)
        {
            return await context.Set<T>()
                                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public virtual async Task<T?> GetEntityAsync(Expression<Func<T, bool>> selector)
        {
            return await context.Set<T>().SingleOrDefaultAsync(selector);
        }

        public virtual async Task<int> GetTotalCount(Expression<Func<T, bool>> selector)
        {
            return await context.Set<T>().CountAsync(selector);
        }

        public async Task SaveAsync()
        {
            _ = await context.SaveChangesAsync();
        }
    }
}
