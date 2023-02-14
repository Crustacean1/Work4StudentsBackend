using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQueryHandler : IRequestHandler<GetRecruiterReviewsQuery, PaginatedList<Review>>
    {
        public readonly IRepository<Recruiter> recruiterRepository;
        public readonly IReviewRepository<OfferReview> reviewRepository;

        public GetRecruiterReviewsQueryHandler(IRepository<Recruiter> recruiterRepository, IReviewRepository<OfferReview> reviewRepository)
        {
            this.recruiterRepository = recruiterRepository;
            this.reviewRepository = reviewRepository;
        }

        public async Task<PaginatedList<Review>> Handle(GetRecruiterReviewsQuery request, CancellationToken cancellationToken)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(request.RecruiterId);
            if (recruiter is null)
            {
                throw new PostingException($"No recruiter with id {request.RecruiterId}", 400);
            }

            var reviews = await reviewRepository.GetReceivedReviews(request.RecruiterId, request);

            return new PaginatedList<Review>(reviews.Items.ToList(), request.Page, request.PageSize, reviews.TotalCount);
        }
    }
}
