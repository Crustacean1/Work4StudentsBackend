using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferQuery : IRequest<JobOffer>
    {
        public Guid OfferId { get; set; }
    }
}
