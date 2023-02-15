using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
        public Guid StudentId { get; set; }
    }
}
