using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record DeleteApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
    }
}
