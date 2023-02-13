using MediatR;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Commands
{
    public record ReviewApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }

        public Guid RecruiterId { get; set; }

        public Review Review { get; set; }
    }
}
