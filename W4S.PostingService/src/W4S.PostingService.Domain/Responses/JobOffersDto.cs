using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Responses
{
    public class JobOffersDto
    {
        public IEnumerable<JobOffer> JobOffers { get; set; }
    }
}
