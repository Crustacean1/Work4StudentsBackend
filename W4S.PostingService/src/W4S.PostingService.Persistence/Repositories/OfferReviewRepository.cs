using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{

    public class OfferReviewRepository : RepositoryBase<OfferReview>, IReviewRepository<OfferReview>
    {
        public OfferReviewRepository(PostingContext context) : base(context)
        {
        }

        public async Task<PaginatedRecords<Review>> GetReceivedReviews(Guid recruiterId, PaginatedQuery query)
        {
            var totalCount = await context.Set<OfferReview>()
                .Include(r => r.Offer)
                .Where(r => r.Offer.RecruiterId == recruiterId)
                .CountAsync();

            var reviews = await context.Set<OfferReview>()
                .Include(r => r.Offer)
                .Where(r => r.Offer.RecruiterId == recruiterId)
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

        public async Task<PaginatedRecords<Review>> GetSubmittedReviews(Guid studentId, PaginatedQuery query)
        {
            var totalCount = await context.Set<OfferReview>()
                .Where(r => r.AuthorId == studentId)
                .CountAsync();

            var reviews = await context.Set<OfferReview>()
                .Where(r => r.AuthorId == studentId)
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

        public async Task<decimal> GetRatingAverage(Guid subjectId)
        {
            return await context.Set<OfferReview>()
                .Include(r => r.Offer)
                .Where(r => r.Offer.Recruiter.Id == subjectId)
                .AverageAsync(r => r.Rating);
        }
    }
}
