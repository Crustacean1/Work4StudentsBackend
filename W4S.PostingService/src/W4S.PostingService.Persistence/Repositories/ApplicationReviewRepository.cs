using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;

namespace W4S.PostingService.Persistence.Repositories
{

    public class ApplicationReviewRepository : RepositoryBase<ApplicationReview>, IReviewRepository<ApplicationReview>
    {
        public ApplicationReviewRepository(PostingContext context) : base(context)
        {
        }

        public async Task<PaginatedRecords<ApplicationReview>> GetReceivedReviews(Guid studentId, PaginatedQuery query)
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

            return new PaginatedRecords<ApplicationReview>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedRecords<ApplicationReview>> GetSubmittedReviews(Guid authorId, PaginatedQuery query)
        {
            var totalCount = await context.Set<ApplicationReview>()
                .Where(r => r.RecruiterId == authorId)
                .CountAsync();

            var reviews = await context.Set<ApplicationReview>()
                .Where(r => r.RecruiterId == authorId)
                .OrderBy(r => r.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<ApplicationReview>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

        public Task<PaginatedRecords<ApplicationReview>> GetDirectReviews(Guid subjectId, PaginatedQuery query)
        {
            throw new NotImplementedException("LMAO xD, to i tak nie dało by nic, bezsens");
        }

        public async Task<decimal> GetRatingAverage(Guid subjectId)
        {
            return await context.Set<ApplicationReview>()
                .Include(r => r.Application)
                .Where(r => r.Application.Student.Id == subjectId)
                .AverageAsync(r => r.Rating);
        }
    }
}
