using System.Linq.Expressions;
using AutoMapper;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQueryHandler
    {
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IMapper mapper;

        public GetOffersQueryHandler(IRepository<JobOffer> offerRepository)
        {
            this.offerRepository = offerRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, GetOffersDto>();
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetOffersDto>> HandleQuery(GetOffersQuery query)
        {
            Expression<Func<JobOffer, bool>> selection = (JobOffer o) => true;
            var rawOffers = await offerRepository.GetEntitiesAsync(query.Page, query.PageSize, selection, o => o.CreationDate);
            var totalCount = await offerRepository.GetTotalCount(selection);

            var offers = rawOffers.Select(offer => mapper.Map<GetOffersDto>(offer));

            return new PaginatedList<GetOffersDto>(offers.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
