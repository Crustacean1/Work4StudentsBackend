using System.Linq.Expressions;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQueryHandler
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<JobOffer> offerRepository;

        public GetOfferApplicationsQueryHandler(IRepository<JobOffer> offerRepository, IRepository<Application> applicationRepository)
        {
            this.offerRepository = offerRepository;
            this.applicationRepository = applicationRepository;
        }

        public async Task<PaginatedList<Application>> HandleQuery(GetOfferApplicationsQuery query)
        {
            var offer = await offerRepository.GetEntityAsync(query.OfferId);
            if (offer is null)
            {
                throw new PostingException($"No offer with id: {query.OfferId}");
            }

            Expression<Func<Application, bool>> selector = (Application a) => a.OfferId == offer.Id;
            var applications = await applicationRepository.GetEntitiesAsync(query.Page, query.PageSize, selector, a => a.LastChanged);
            var totalCount = await applicationRepository.GetTotalCount(selector);

            return new PaginatedList<Application>(applications.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
