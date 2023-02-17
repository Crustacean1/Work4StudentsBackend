using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<GetApplicationDto>>
    {
        public Guid RecruiterId { get; set; }
        public Guid OfferId { get; set; }
    }
}
