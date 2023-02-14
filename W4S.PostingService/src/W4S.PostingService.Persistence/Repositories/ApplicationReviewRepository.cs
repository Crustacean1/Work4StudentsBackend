using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{

    public class ApplicationReviewRepository : RepositoryBase<ApplicationReview>, IReviewRepository<ApplicationReview>
    {
        public ApplicationReviewRepository(PostingContext context) : base(context)
        {
        }

        public async Task<PaginatedRecords<Review>> GetReceivedReviews(Guid studentId, PaginatedQuery query)
        {
            var totalCount = await context.Set<ApplicationReview>()
                .Include(r => r.Application)
                .Where(r => r.Application.StudentId == studentId)
                .CountAsync();

            var reviews = await context.Set<ApplicationReview>()
                .Include(r => r.Application)
                .Where(r => r.Application.StudentId == studentId)
                .OrderBy(r => r.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<Review>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedRecords<Review>> GetSubmittedReviews(Guid authorId, PaginatedQuery query)
        {
            var totalCount = await context.Set<ApplicationReview>()
                .Where(r => r.AuthorId == authorId)
                .CountAsync();

            var reviews = await context.Set<ApplicationReview>()
                .Where(r => r.AuthorId == authorId)
                .OrderBy(r => r.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<Review>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

    }
}
