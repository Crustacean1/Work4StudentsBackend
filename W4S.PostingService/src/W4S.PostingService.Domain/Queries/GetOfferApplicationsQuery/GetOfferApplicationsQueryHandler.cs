using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferApplicationsQueryHandler : IRequestHandler<GetOfferApplicationsQuery, PaginatedList<GetApplicationDto>>
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public GetOfferApplicationsQueryHandler(IOfferRepository offerRepository, IRepository<Application> applicationRepository)
        {
            this.offerRepository = offerRepository;
            this.applicationRepository = applicationRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<Application, GetApplicationDto>()
                .ForMember(a => a.Status, opt => opt.MapFrom(a => Enum.GetName(typeof(ApplicationStatus), a.Status)));
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetApplicationDto>> Handle(GetOfferApplicationsQuery query, CancellationToken cancellationToken)
        {
            var offer = await offerRepository.GetEntityAsync(query.OfferId);
            if (offer is null)
            {
                throw new PostingException($"No offer with id: {query.OfferId}");
            }

            Expression<Func<Application, bool>> selector = (Application a) => a.OfferId == offer.Id;
            var rawApplications = await applicationRepository.GetEntitiesAsync(query.Page, query.PageSize, selector, a => a.LastChanged);
            var totalCount = await applicationRepository.GetTotalCount(selector);

            var applications = rawApplications.Select(a => mapper.Map<GetApplicationDto>(a));

            return new PaginatedList<GetApplicationDto>(applications.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
