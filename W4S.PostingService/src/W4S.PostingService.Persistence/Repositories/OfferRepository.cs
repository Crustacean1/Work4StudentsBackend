using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

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
                b.CreateMap<Company, CompanyDto>();
                b.CreateMap<JobOffer, GetOfferDto>()
                .ForMember(dto => dto.Company, opts => opts.MapFrom(jo => jo.Recruiter.Company));
            });
            mapper = mapperConfiguration.CreateMapper();
            this.logger = logger;
        }

        public async Task<PaginatedRecords<GetOfferDto>> GetOffers(GetOffersQuery query)
        {
            logger.LogInformation("Most curious {Count}", query.Keywords);

            var keywordsArNull = string.IsNullOrEmpty(query.Keywords);
            var modeIsNull = Enum.TryParse(query.Mode, out WorkMode mode);
            var statusIsNull = Enum.TryParse(query.Status, out OfferStatus status);

            var totalCount = await context.Set<JobOffer>()
                .Where(o => keywordsArNull || o.SearchVector.Matches(query.Keywords))
                .Where(o => modeIsNull || o.Mode == mode)
                .Where(o => statusIsNull || o.Status == status)
                .CountAsync();

            var offers = await context.Set<JobOffer>()
                .Where(o => keywordsArNull || o.SearchVector.Matches(query.Keywords))
                .Where(o => modeIsNull || o.Mode == mode)
                .Where(o => statusIsNull || o.Status == status)
                .Include(jo => jo.Recruiter)
                .ThenInclude(r => r.Company)
                .OrderBy(jo => jo.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<GetOfferDto>
            {
                Items = offers.Select(mapper.Map<GetOfferDto>),
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
