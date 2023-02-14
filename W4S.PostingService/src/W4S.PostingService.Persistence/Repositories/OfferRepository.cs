using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Persistence.Repositories
{
    public class OfferRepository : RepositoryBase<JobOffer>, IOfferRepository
    {
        private readonly IMapper mapper;
        private ILogger<OfferRepository> logger;

        public OfferRepository(PostingContext context, ILogger<OfferRepository> logger) : base(context)
        {
            var mapperConfiguration = new MapperConfiguration(b =>
            {
                b.CreateMap<JobOffer, GetOffersDto>();
                b.CreateMap<JobOffer, GetOfferDto>()
                .ForMember(dto => dto.Company, opts => opts.MapFrom(jo => jo.Recruiter.Company));
            });
            mapper = mapperConfiguration.CreateMapper();
            this.logger = logger;
        }

        public async Task<PaginatedRecords<GetOffersDto>> GetOffers(GetOffersQuery query)
        {
            var keywords = string.IsNullOrEmpty(query.Keywords) ? new List<string>() : query.Keywords.Split(" ", StringSplitOptions.TrimEntries).ToList();

            var totalCount = await context.Set<JobOffer>()

                /*.Where(jo => keywords.Count() == 0
                || keywords.Any(cat => jo.Description.Contains(cat))
                || keywords.Any(cat => jo.Title.Contains(cat))
                || keywords.Any(cat => jo.Role.Contains(cat)))*/
                .CountAsync();

            logger.LogInformation("Most curious {Coutn}", keywords.Count());

            var offers = await context.Set<JobOffer>()
                .Where(o => o.SearchVector.Matches(EF.Functions.ToTsQuery(query.Keywords)))
                .OrderBy(jo => jo.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<GetOffersDto>
            {
                Items = offers.Select(mapper.Map<GetOffersDto>),
                TotalCount = totalCount
            };
        }

        public async Task<GetOfferDto> GetOfferDetails(Guid id)
        {
            var offer = await context.Set<JobOffer>()
                .Include(jo => jo.Recruiter)
                .ThenInclude(r => r.Company)
                .SingleOrDefaultAsync(jo => jo.Id == id);

            return mapper.Map<GetOfferDto>(offer);
        }
    }
}
