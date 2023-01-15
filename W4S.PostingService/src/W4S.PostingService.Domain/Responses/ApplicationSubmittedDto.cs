namespace W4S.PostingService.Domain.Responses
{

    public class ApplicationSubmittedDto
    {
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
