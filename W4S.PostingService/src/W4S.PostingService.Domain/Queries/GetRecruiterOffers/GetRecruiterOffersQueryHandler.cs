using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

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
            var recruiter = await recruiterRepository.GetEntityAsync(query.RecruiterId);
            if (recruiter is null)
            {
                throw new PostingException($"No recruiter with id: {query.RecruiterId}", 400);
            }

            Expression<Func<JobOffer, bool>> selector = (JobOffer o) => o.RecruiterId == recruiter.Id;

            var rawOffers = await offerRepository.GetEntitiesAsync(query.Page, query.PageSize, selector, o => o.CreationDate);
            var totalCount = await offerRepository.GetTotalCount(selector);

            var offers = rawOffers.Select(offer => mapper.Map<GetOfferDto>(offer));

            logger.LogInformation("GetRecruiterOffersQueryHandler: Found: {RecordCount} with {TotalCount} total", offers.Count(), totalCount);

            return new PaginatedList<GetOfferDto>(offers.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
