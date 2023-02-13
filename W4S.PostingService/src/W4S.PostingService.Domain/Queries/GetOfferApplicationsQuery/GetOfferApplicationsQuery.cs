using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<Application>>
    {
        public GetOfferApplicationsQuery(int page, int pageSize) : base(page, pageSize) { }

        public Guid OfferId { get; set; }
    }
}
