using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOffersDto>>
    {
        public Guid RecruiterId { get; set; }
    }
}
