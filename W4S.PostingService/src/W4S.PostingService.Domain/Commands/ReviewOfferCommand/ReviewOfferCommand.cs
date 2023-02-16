using MediatR;
using W4S.PostingService.Domain.Dto;

namespace W4S.PostingService.Domain.Commands
{
    public record ReviewOfferCommand : IRequest<Guid>
    {
        public Guid OfferId { get; set; }

        public Guid StudentId { get; set; }

        public PostReviewDto Review { get; set; }
    }
}
