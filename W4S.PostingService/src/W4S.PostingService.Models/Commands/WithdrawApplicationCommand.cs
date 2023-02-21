using MediatR;

namespace W4S.PostingService.Models.Commands
{
    public class WithdrawApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
        public Guid StudentId { get; set; }
    }
}
