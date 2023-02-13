using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, PaginatedList<GetOffersDto>>
    {
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IMapper mapper;

        public GetOffersQueryHandler(IRepository<JobOffer> offerRepository)
        {
            this.offerRepository = offerRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, GetOffersDto>().ForMember(o => o.Status, config => config.MapFrom(o => Enum.GetName(typeof(OfferStatus), o.Status)));
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetOffersDto>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<JobOffer, bool>> selection = (JobOffer o) => true;
            if (request.Keywords.Any())
            {
                //selection = (JobOffer o) => o.Title.Split(" ", StringSplitOptions.TrimEntries)
                //.Any(titlePart => request.Keywords.Any(keyword => keyword.ToLower() == titlePart.ToLower()));
            }

            var rawOffers = await offerRepository.GetEntitiesAsync(request.Page, request.PageSize, selection, o => o.CreationDate);
            var totalCount = await offerRepository.GetTotalCount(selection);

            var offers = rawOffers.Select(offer => mapper.Map<GetOffersDto>(offer));

            return new PaginatedList<GetOffersDto>(offers.ToList(), request.Page, request.PageSize, totalCount);
        }
    }
}
