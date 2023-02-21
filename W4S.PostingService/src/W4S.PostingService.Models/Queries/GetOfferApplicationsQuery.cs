using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetOfferApplicationsQuery : PaginatedQuery, IRequest<PaginatedList<GetApplicationDto>>
    {
        public Guid RecruiterId { get; set; }
        public Guid OfferId { get; set; }
    }
}
