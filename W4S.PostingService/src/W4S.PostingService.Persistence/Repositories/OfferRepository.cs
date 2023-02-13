using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Persistence.Repositories
{
    public class OfferRepository : RepositoryBase<JobOffer>
    {
        public OfferRepository(PostingContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<JobOffer>> GetEntitiesAsync(int page, int pageSize, Expression<Func<JobOffer, bool>> selector, Expression<Func<JobOffer, object>> comparator)
        {
            var result = context.Set<JobOffer>()
                .Where(selector)
                .Include(jo => jo.WorkingHours)
                .OrderBy(comparator)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return await result.ToListAsync();
        }

        public override async Task<IEnumerable<JobOffer>> GetEntitiesAsync(Expression<Func<JobOffer, bool>> selector)
        {
            IEnumerable<JobOffer> result = await context.Set<JobOffer>()
                .Include(jo => jo.WorkingHours)
                .Where(selector)
                .ToListAsync();
            return result;
        }

        public override async Task<JobOffer?> GetEntityAsync(Guid id)
        {
            return await context.Set<JobOffer>()
                .Include(jo => jo.WorkingHours)
                .SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}
