using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQueryHandler : IRequestHandler<GetRecruiterReviewsQuery, PaginatedList<OfferReviewDto>>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IReviewRepository<OfferReview> reviewRepository;
        private readonly IMapper mapper;

        public GetRecruiterReviewsQueryHandler(IRepository<Recruiter> recruiterRepository, IReviewRepository<OfferReview> reviewRepository)
        {
            this.recruiterRepository = recruiterRepository;
            this.reviewRepository = reviewRepository;

            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<OfferReview, OfferReviewDto>();
            });
            this.mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<OfferReviewDto>> Handle(GetRecruiterReviewsQuery request, CancellationToken cancellationToken)
        {
            _ = await recruiterRepository.RequireEntityAsync(request.RecruiterId);
            var reviews = await reviewRepository.GetReceivedReviews(request.RecruiterId, request);

            return new PaginatedList<OfferReviewDto>(reviews.Items.Select(mapper.Map<OfferReviewDto>).ToList(), request.Page, request.PageSize, reviews.TotalCount);
        }
    }
}
