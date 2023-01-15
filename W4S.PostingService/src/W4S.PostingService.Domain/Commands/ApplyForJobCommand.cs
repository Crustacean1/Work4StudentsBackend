namespace W4S.PostingService.Domain.Commands
{
    public class ApplyForJobCommand
    {
        public Guid ApplicantId { get; set; }
        public Guid OfferId { get; set; }
    }
}
