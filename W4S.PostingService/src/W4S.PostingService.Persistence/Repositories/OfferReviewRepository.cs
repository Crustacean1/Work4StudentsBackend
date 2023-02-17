using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;

namespace W4S.PostingService.Persistence.Repositories
{

    public class OfferReviewRepository : RepositoryBase<OfferReview>, IReviewRepository<OfferReview>
    {
        public OfferReviewRepository(PostingContext context) : base(context)
        {
        }

        public async Task<PaginatedRecords<OfferReview>> GetReceivedReviews(Guid recruiterId, PaginatedQuery query)
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

            return new PaginatedRecords<OfferReview>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedRecords<OfferReview>> GetSubmittedReviews(Guid studentId, PaginatedQuery query)
        {
            var totalCount = await context.Set<OfferReview>()
                .Where(r => r.StudentId == studentId)
                .CountAsync();

            var reviews = await context.Set<OfferReview>()
                .Where(r => r.StudentId == studentId)
                .OrderBy(r => r.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<OfferReview>
            {
                Items = reviews,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedRecords<OfferReview>> GetDirectReviews(Guid subjectId, PaginatedQuery query)
        {
            var totalCount = await context.Set<OfferReview>()
                .Where(r => r.OfferId == subjectId)
                .CountAsync();

            var reviews = await context.Set<OfferReview>()
                .Where(r => r.OfferId == subjectId)
                .OrderBy(r => r.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<OfferReview>
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
