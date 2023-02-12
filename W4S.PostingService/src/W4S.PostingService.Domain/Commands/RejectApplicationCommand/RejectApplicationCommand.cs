namespace W4S.PostingService.Domain.Commands
{
    public class RejectApplicationCommand
    {
        public Guid ApplicationId { get; set; }
        public Guid RecruiterId { get; set; }
    }
}
