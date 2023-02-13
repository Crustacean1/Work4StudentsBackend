using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record RejectApplicationCommand : IRequest
    {
        public Guid ApplicationId { get; set; }
        public Guid RecruiterId { get; set; }
    }
}
