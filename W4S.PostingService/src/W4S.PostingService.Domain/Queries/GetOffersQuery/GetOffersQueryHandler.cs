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
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public GetOffersQueryHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, GetOffersDto>()
                .ForMember(o => o.Status, config => config.MapFrom(o => Enum.GetName(typeof(OfferStatus), o.Status)))
                .ForMember(o => o.Mode, config => config.MapFrom(o => Enum.GetName(typeof(WorkMode), o.Mode)));
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetOffersDto>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await offerRepository.GetOffers(request);

            return new PaginatedList<GetOffersDto>(offers.Items.ToList(), request.Page, request.PageSize, offers.TotalCount);
        }
    }
}
