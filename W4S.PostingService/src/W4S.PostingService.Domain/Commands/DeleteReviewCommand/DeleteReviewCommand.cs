using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record DeleteReviewCommand : IRequest<Guid>
    {
        public Guid ReviewId { get; set; }
    }
}
