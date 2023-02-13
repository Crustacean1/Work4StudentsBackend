using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQueryHandler : IRequestHandler<GetRecruiterReviewsQuery, PaginatedList<Review>>
    {
        public readonly IRepository<Recruiter> recruiterRepository;
        public readonly IReviewRepository reviewRepository;

        public GetRecruiterReviewsQueryHandler(IRepository<Recruiter> recruiterRepository, IReviewRepository reviewRepository)
        {
            this.recruiterRepository = recruiterRepository;
            this.reviewRepository = reviewRepository;
        }

        public async Task<PaginatedList<Review>> Handle(GetRecruiterReviewsQuery query, CancellationToken cancellationToken)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(query.RecruiterId);
            if (recruiter is null)
            {
                throw new PostingException($"No recruiter with id {query.RecruiterId}", 400);
            }

            var reviews = await reviewRepository.GetRecruiterReviews(query.RecruiterId, query.Page, query.PageSize);
            var reviewCount = await reviewRepository.GetRecruiterReviewCount(query.RecruiterId);

            return new PaginatedList<Review>(reviews.ToList(), query.Page, query.PageSize, reviewCount);
        }
    }
}
