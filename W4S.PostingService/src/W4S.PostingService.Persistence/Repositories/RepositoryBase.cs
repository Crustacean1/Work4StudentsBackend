using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly PostingContext context;

        public RepositoryBase(PostingContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            await context.JobOffers.Where(o => o.Id == id).ExecuteDeleteAsync();
        }

        public Task<IEnumerable<T>> GetEntitiesAsync(int pageSize, int pageSkip, Expression<Func<T, T, bool>> comparator)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(Expression<Func<T, bool>> selector)
        {
            IEnumerable<T> result = await context.Set<T>().Where(selector).ToListAsync();
            return result;
        }

        public async Task<T?> GetEntityAsync(Guid id)
        {
            return await context.Set<T>().SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
