using MediatR;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOffersDto>>
    {
        public GetOffersQuery(int page, int pageSize) : base(page, pageSize) { }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Keywords { get; set; }
    }
}
