using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record RejectApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
        public Guid RecruiterId { get; set; }
    }
}
