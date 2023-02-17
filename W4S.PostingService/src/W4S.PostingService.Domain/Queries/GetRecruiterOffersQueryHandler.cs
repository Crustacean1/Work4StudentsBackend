using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQueryHandler : IRequestHandler<GetRecruiterOffersQuery, PaginatedList<GetOfferDto>>
    {
        private readonly ILogger<GetRecruiterOffersQueryHandler> logger;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public GetRecruiterOffersQueryHandler(IRepository<Recruiter> recruiterRepository, IOfferRepository offerRepository, ILogger<GetRecruiterOffersQueryHandler> logger)
        {
            this.recruiterRepository = recruiterRepository;
            this.offerRepository = offerRepository;
            this.logger = logger;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<Company, CompanyDto>();
                b.CreateMap<JobOffer, GetOfferDto>()
                .ForMember(o => o.Company, config => config.MapFrom(o => o.Recruiter.Company));
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetOfferDto>> Handle(GetRecruiterOffersQuery query, CancellationToken cancellationToken)
        {
            _ = await recruiterRepository.RequireEntityAsync(query.RecruiterId);

            var offers = await offerRepository.GetRecruiterOffers(query.RecruiterId, query);

            logger.LogInformation("GetRecruiterOffersQueryHandler: Found: {RecordCount} with {TotalCount} total", offers.Items.Count(), offers.TotalCount);

            return new PaginatedList<GetOfferDto>(offers.Items.ToList(), query.Page, query.PageSize, offers.TotalCount);
        }
    }
}
