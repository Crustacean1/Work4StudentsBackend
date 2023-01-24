namespace W4S.PostingService.Domain.Responses
{
    public record ApplicationSubmittedDto : ResponseBase
    {
        public Guid Id { get; set; }
    }
}
