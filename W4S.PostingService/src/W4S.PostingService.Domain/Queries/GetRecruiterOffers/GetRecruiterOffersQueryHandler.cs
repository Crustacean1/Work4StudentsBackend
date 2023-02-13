using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetRecruiterOffersQueryHandler
    {
        private readonly ILogger<GetRecruiterOffersQueryHandler> logger;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IMapper mapper;

        public GetRecruiterOffersQueryHandler(IRepository<Recruiter> recruiterRepository, IRepository<JobOffer> offerRepository, ILogger<GetRecruiterOffersQueryHandler> logger)
        {
            this.recruiterRepository = recruiterRepository;
            this.offerRepository = offerRepository;
            this.logger = logger;
            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, GetOffersDto>();
            });
            mapper = mapperConfig.CreateMapper();
        }

        public async Task<PaginatedList<GetOffersDto>> HandleQuery(GetRecruiterOffersQuery query)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(query.RecrutierId);
            if (recruiter is null)
            {
                throw new PostingException($"No recruiter with id: {query.RecrutierId}", 400);
            }

            Expression<Func<JobOffer, bool>> selector = (JobOffer o) => o.RecruiterId == recruiter.Id;

            var rawOffers = await offerRepository.GetEntitiesAsync(query.Page, query.PageSize, selector, o => o.CreationDate);
            var totalCount = await offerRepository.GetTotalCount(selector);

            var offers = rawOffers.Select(offer => mapper.Map<GetOffersDto>(offer));

            logger.LogInformation("GetRecruiterOffersQueryHandler: Found: {RecordCount} with {TotalCount} total", offers.Count(), totalCount);

            return new PaginatedList<GetOffersDto>(offers.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
