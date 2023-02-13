using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<GetApplicationDto>>
    {
        public GetOfferApplicationsQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid OfferId { get; set; }
    }
}
