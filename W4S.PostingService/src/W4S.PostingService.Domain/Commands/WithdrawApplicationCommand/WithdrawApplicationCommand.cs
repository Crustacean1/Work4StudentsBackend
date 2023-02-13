using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommand : IRequest
    {
        public Guid ApplicationId { get; set; }
        public Guid StudentId { get; set; }
    }
}
