using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record DeleteApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
    }
}
