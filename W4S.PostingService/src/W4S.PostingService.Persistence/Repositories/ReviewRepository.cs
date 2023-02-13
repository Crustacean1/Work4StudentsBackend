using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(PostingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetRecruiterSubmittedReviews(Guid recruiterId, int page, int pageSize)
        {
            return await context.Set<Review>()
                .Where(r => r.AuthorId == recruiterId)
                .OrderBy(r => r.CreationDate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetRecruiterSubmittedReviewCount(Guid recruiterId)
        {
            return await context.Set<Review>()
                .Where(r => r.AuthorId == recruiterId)
                .CountAsync();
        }

        public async Task<IEnumerable<Review>> GetStudentSubmittedReviews(Guid studentId, int page, int pageSize)
        {

            return await context.Set<Review>()
                .Where(r => r.AuthorId == studentId)
                .OrderBy(r => r.CreationDate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetStudentSubmittedReviewCount(Guid studentId)
        {
            return await context.Set<Review>()
                .Where(r => r.AuthorId == studentId)
                .CountAsync();
        }

        public async Task<IEnumerable<Review>> GetRecruiterReviews(Guid recruiterId, int page, int pageSize)
        {
            return await context.Set<JobOffer>()
                .Where(a => a.RecruiterId == recruiterId)
                .Join(context.Set<Review>(), o => o.Id, r => r.SubjectId, (o, r) => new { Offer = o, Review = r })
                .OrderBy(ag => ag.Review.CreationDate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(ag => ag.Review)
                .ToListAsync();
        }

        public async Task<int> GetRecruiterReviewCount(Guid recruiterId)
        {
            return await context.Set<JobOffer>()
                .Where(a => a.RecruiterId == recruiterId)
                .Join(context.Set<Review>(), o => o.Id, r => r.SubjectId, (o, r) => 1)
                .CountAsync();
        }

        public async Task<IEnumerable<Review>> GetStudentReviews(Guid studentId, int page, int pageSize)
        {
            return await context.Set<Application>()
                .Where(a => a.StudentId == studentId)
                .Join(context.Set<Review>(), a => a.Id, r => r.SubjectId, (o, r) => new { Offer = o, Review = r })
                .OrderBy(ag => ag.Review.CreationDate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(ag => ag.Review)
                .ToListAsync();
        }

        public async Task<int> GetStudentReviewCount(Guid studentId)
        {
            return await context.Set<Application>()
                .Where(a => a.StudentId == studentId)
                .Join(context.Set<Review>(), a => a.Id, r => r.SubjectId, (o, r) => 1)
                .CountAsync();
        }
    }
}
