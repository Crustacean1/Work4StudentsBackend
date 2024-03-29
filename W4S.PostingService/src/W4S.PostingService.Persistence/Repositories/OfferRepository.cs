using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

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
                b.CreateMap<JobOffer, GetOfferDetailsDto>()
                .ForMember(dto => dto.Company, opts => opts.MapFrom(jo => jo.Recruiter.Company));
            });
            mapper = mapperConfiguration.CreateMapper();
            this.logger = logger;
        }

        public async Task<PaginatedRecords<GetOfferDto>> GetOffers(GetOffersQuery query)
        {
            var keywordsAreNull = string.IsNullOrEmpty(query.Keywords);
            var modeIsNull = Enum.TryParse(query.Mode, out WorkMode mode);
            var statusIsNull = Enum.TryParse(query.Status, out OfferStatus status);

            var totalCount = await context.Set<JobOffer>()
                .Where(o => keywordsAreNull || o.SearchVector.Matches(query.Keywords!))
                .Where(o => modeIsNull || o.Mode == mode)
                .Where(o => statusIsNull || o.Status == status)
                .CountAsync();

            var offers = await context.Set<JobOffer>()
                .Where(o => keywordsAreNull || o.SearchVector.Matches(query.Keywords!))
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
                Items = offers.Select(mapper.Map<JobOffer, GetOfferDto>),
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedRecords<GetOfferDto>> GetRecruiterOffers(Guid recruiterId, PaginatedQuery query)
        {
            var totalCount = await context.Set<JobOffer>()
                .Where(o => o.RecruiterId == recruiterId)
                .CountAsync();

            var offers = await context.Set<JobOffer>()
                .Where(o => o.RecruiterId == recruiterId)
                .Include(jo => jo.Recruiter)
                .ThenInclude(r => r.Company)
                .OrderBy(jo => jo.CreationDate)
                .Skip(query.RecordsToSkip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedRecords<GetOfferDto>
            {
                Items = offers.Select(mapper.Map<JobOffer, GetOfferDto>),
                TotalCount = totalCount
            };
        }

        public async Task<GetOfferDetailsDto?> GetOfferDetails(Guid id, Guid userId)
        {
            var offer = await context.Set<JobOffer>()
                .Include(jo => jo.Recruiter)
                .ThenInclude(r => r.Company)
                .SingleOrDefaultAsync(jo => jo.Id == id);

            if (offer is null)
            {
                return null;
            }

            var application = await context.Set<Application>()
                .SingleOrDefaultAsync(a => a.OfferId == id && (a.Status == ApplicationStatus.Submitted || a.Status == ApplicationStatus.Accepted) && a.StudentId == userId);

            var applied = application is Application offerApplication;


            return mapper.Map<JobOffer, GetOfferDetailsDto>(offer, opt => opt.AfterMap((src, dst) =>
                        {
                            dst.Created = src.RecruiterId == userId;
                            dst.Applied = applied;
                            dst.ApplicationId = application?.Id ?? Guid.Empty;
                        }));
        }
    }
}
