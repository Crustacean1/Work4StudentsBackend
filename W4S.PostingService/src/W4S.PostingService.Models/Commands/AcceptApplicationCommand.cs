using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public record AcceptApplicationCommand : IRequest<Guid>
    {
        public Guid RecruiterId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
