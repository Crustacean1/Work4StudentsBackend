using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferReviewsQueryHandler : IRequestHandler<GetOfferReviewsQuery, PaginatedList<OfferReviewDto>>
    {
        private readonly IReviewRepository<OfferReview> reviewRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public GetOfferReviewsQueryHandler(IReviewRepository<OfferReview> reviewRepository, IOfferRepository offerRepository)
        {
            this.reviewRepository = reviewRepository;
            this.offerRepository = offerRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<OfferReview, OfferReviewDto>();
            });
            this.mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<OfferReviewDto>> Handle(GetOfferReviewsQuery query, CancellationToken cancellationToken)
        {
            _ = await offerRepository.RequireEntityAsync(query.OfferId);

            var reviews = await reviewRepository.GetDirectReviews(query.OfferId, query);

            return new PaginatedList<OfferReviewDto>
            {
                Items = reviews.Items.Select(mapper.Map<OfferReviewDto>).ToList(),
                MetaData = new MetaData
                {
                    Page = query.Page,
                    PageSize = query.PageSize,
                    TotalCount = reviews.TotalCount
                }
            };

        }
    }
}
