namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommand
    {
        public Guid ApplicationId { get; set; }
        public Guid ApplicantId { get; set; }
    }
}