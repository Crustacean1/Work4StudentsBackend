using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record DeleteReviewCommand : IRequest<Guid>
    {
        public Guid ReviewId { get; set; }
    }
}
