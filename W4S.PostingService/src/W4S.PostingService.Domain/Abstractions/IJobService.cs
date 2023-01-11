namespace W4S.PostingService.Domain.Abstractions
{
    public interface IJobService
    {
        Task<Guid> PostJobOffer(CreateJobOfferCommand command);
    }
}
