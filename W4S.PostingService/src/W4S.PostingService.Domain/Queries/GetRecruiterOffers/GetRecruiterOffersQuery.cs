using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOfferDto>>
    {
        public Guid RecruiterId { get; set; }
    }
}
