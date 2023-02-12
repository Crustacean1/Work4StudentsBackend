namespace W4S.PostingService.Domain.Commands
{
    public class AcceptApplicationCommand
    {
        public Guid RecruiterId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
