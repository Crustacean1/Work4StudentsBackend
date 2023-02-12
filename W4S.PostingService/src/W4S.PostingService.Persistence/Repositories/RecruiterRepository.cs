using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Persistence.Repositories
{
    public class RecruiterRepository : RepositoryBase<Recruiter>
    {
        public RecruiterRepository(PostingContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Recruiter>> GetEntitiesAsync(int page, int pageSize, Expression<Func<Recruiter, bool>> selector, Expression<Func<Recruiter, object>> comparator)
        {
            var result = context.Set<Recruiter>()
                .Include(r => r.Offers)
                .Include(r => r.Company)
                .Where(selector)
                .OrderBy(comparator)
                .Skip(page * pageSize)
                .Take(pageSize);
            return await result.ToListAsync();
        }

        public override async Task<IEnumerable<Recruiter>> GetEntitiesAsync(Expression<Func<Recruiter, bool>> selector)
        {
            IEnumerable<Recruiter> result = await context.Set<Recruiter>()
                .Include(r => r.Offers)
                .Include(r => r.Company)
                .Where(selector)
                .ToListAsync();
            return result;
        }

        public override async Task<Recruiter?> GetEntityAsync(Guid id)
        {
            return await context.Set<Recruiter>()
                .Include(r => r.Offers)
                .SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}
