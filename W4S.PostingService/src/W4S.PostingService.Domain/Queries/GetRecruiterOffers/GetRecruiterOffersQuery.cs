using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOffersDto>>
    {
        public GetRecruiterOffersQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid RecrutierId { get; set; }
    }
}
