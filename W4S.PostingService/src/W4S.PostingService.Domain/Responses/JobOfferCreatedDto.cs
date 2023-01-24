namespace W4S.PostingService.Domain.Responses
{

    public record JobOfferCreatedDto : ResponseBase
    {
        public Guid Id { get; set; }
    }
}
