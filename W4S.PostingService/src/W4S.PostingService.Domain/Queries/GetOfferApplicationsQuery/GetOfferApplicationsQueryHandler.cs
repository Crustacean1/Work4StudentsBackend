using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly ILogger<GetOfferApplicationsQueryHandler> logger;
        private readonly IMapper mapper;

        public GetOfferApplicationsQueryHandler(IOfferRepository offerRepository, IApplicationRepository applicationRepository, ILogger<GetOfferApplicationsQueryHandler> logger, IRepository<Recruiter> recruiterRepository)
        {
            this.offerRepository = offerRepository;
            this.applicationRepository = applicationRepository;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, ApplicationOfferDto>()
                .ForMember(a => a.Company, opt => opt.MapFrom(s => s.Recruiter.Company.Name));

                b.CreateMap<Application, GetApplicationDto>()
                .ForMember(a => a.Status, opt => opt.MapFrom(a => Enum.GetName(typeof(ApplicationStatus), a.Status)))
                .ForMember(a => a.Distance, opt => opt.MapFrom(s => double.IsFinite(s.Distance) ? s.Distance : 0))
                .ForMember(a => a.WorkTimeOverlap, opt => opt.MapFrom(s => double.IsFinite(s.WorkTimeOverlap) ? s.WorkTimeOverlap : 0));

            });
            mapper = mapperConfig.CreateMapper();
            this.logger = logger;
            this.recruiterRepository = recruiterRepository;
        }

        public async Task<PaginatedList<GetApplicationDto>> Handle(GetOfferApplicationsQuery query, CancellationToken cancellationToken)
        {
            var offer = await offerRepository.GetEntityAsync(query.OfferId);
            if (offer is null)
            {
                throw new PostingException($"No offer with id: {query.OfferId}");
            }

            var recruiter = await recruiterRepository.RequireEntityAsync(query.RecruiterId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Recruiter {query.RecruiterId} does not have access to {query.OfferId}", 403);
            }

            var applications = await applicationRepository.GetOfferApplications(query.OfferId, query);

            return new PaginatedList<GetApplicationDto>(applications.Items.Select(mapper.Map<GetApplicationDto>).ToList(),
                    query.Page, query.PageSize, applications.TotalCount);
        }
    }
}
