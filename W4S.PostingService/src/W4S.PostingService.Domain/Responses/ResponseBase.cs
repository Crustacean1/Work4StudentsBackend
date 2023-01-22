namespace W4S.PostingService.Domain.Responses
{
    public record ResponseBase
    {
        public List<string> Errors { get; set; }
    }
}
