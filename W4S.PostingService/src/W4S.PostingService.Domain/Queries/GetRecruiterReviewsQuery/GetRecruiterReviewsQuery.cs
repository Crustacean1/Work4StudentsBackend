using MediatR;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterReviewsQuery : PaginatedQuery, IRequest<PaginatedList<OfferReviewDto>>
    {
        public Guid RecruiterId { get; set; }
    }
}
