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
        private readonly IApplicationRepository applicationRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public GetOfferApplicationsQueryHandler(IOfferRepository offerRepository, IApplicationRepository applicationRepository)
        {
            this.offerRepository = offerRepository;
            this.applicationRepository = applicationRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, ApplicationOfferDto>()
                .ForMember(a => a.Company, opt => opt.MapFrom(s => s.Recruiter.Company.Name));

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

            var applications = await applicationRepository.GetOfferApplications(query.OfferId, query);

            return new PaginatedList<GetApplicationDto>(applications.Items.Select(mapper.Map<GetApplicationDto>).ToList(),
                    query.Page, query.PageSize, applications.TotalCount);
        }
    }
}
