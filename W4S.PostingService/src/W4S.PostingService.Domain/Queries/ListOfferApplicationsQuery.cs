namespace W4S.PostingService.Domain.Queries
{
    public class ListOfferApplicationsQuery
    {
        public Guid OfferId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
