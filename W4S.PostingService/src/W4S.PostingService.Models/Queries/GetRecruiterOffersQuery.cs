using MediatR;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Queries
{
    public class GetRecruiterOffersQuery : PaginatedQuery, IRequest<PaginatedList<GetOfferDto>>
    {
        public Guid RecruiterId { get; set; }
    }
}
