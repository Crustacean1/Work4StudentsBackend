using System.Linq.Expressions;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQueryHandler
    {
        private readonly IRepository<JobOffer> offerRepository;

        public GetOffersQueryHandler(IRepository<JobOffer> offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<PaginatedList<JobOffer>> HandleQuery(GetOffersQuery query)
        {
            Expression<Func<JobOffer, bool>> selection = (JobOffer o) => true;
            var offers = await offerRepository.GetEntitiesAsync(query.Page, query.PageSize, selection, o => o.CreationDate);
            var totalCount = await offerRepository.GetTotalCount(selection);

            return new PaginatedList<JobOffer>(offers.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
