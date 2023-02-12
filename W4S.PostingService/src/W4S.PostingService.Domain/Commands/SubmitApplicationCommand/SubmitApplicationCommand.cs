namespace W4S.PostingService.Domain.Commands
{
    public class SubmitApplicationCommand
    {
        public Guid StudentId { get; set; }

        public Guid OfferId { get; set; }

        public SubmitApplicationDto Application { get; set; }
    }
}
