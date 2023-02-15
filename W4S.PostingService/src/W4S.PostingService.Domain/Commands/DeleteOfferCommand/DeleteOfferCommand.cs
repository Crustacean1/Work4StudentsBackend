namespace W4S.PostingService.Domain.Commands
{
    public record DeleteOfferCommand
    {
        public Guid OfferId { get; set; }
    }
}
