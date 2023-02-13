using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record AcceptApplicationCommand : IRequest
    {
        public Guid RecruiterId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
