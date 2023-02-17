using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(PostingContext context) : base(context)
        {

        }

        public async Task<PaginatedRecords<Application>> GetStudentApplications(Guid userId, PaginatedQuery query)
        {

            var totalCount = await context.Set<Application>()
                .Where(a => a.StudentId == userId)
                .CountAsync();

            var offers = await context.Set<Application>()
                .Include(a => a.Offer)
                .ThenInclude(o => o.Recruiter)
                .ThenInclude(r => r.Company)
                .Where(a => a.StudentId == userId)
                .OrderBy(r => r.LastChanged)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<Application>
            {
                Items = offers,
                TotalCount = totalCount
            };
        }
        public async Task<PaginatedRecords<Application>> GetOfferApplications(Guid offerId, PaginatedQuery query)
        {
            var totalCount = await context.Set<Application>()
                .Where(a => a.OfferId == offerId)
                .CountAsync();

            var applications = await context.Set<Application>()
                .Where(a => a.OfferId == offerId)
                .Include(a => a.Offer)
                .ThenInclude(o => o.Recruiter)
                .ThenInclude(r => r.Company)
                .OrderBy(r => r.LastChanged)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<Application>
            {
                Items = applications,
                TotalCount = totalCount
            };
        }
    }
}
