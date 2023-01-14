namespace W4S.PostingService.Domain.Responses
{

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
