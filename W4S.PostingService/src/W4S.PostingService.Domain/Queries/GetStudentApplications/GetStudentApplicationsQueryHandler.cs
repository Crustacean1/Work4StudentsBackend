using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentApplicationsQueryHandler : IRequestHandler<GetStudentApplicationsQuery, PaginatedList<GetApplicationDto>>
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public GetStudentApplicationsQueryHandler(IRepository<Student> studentRepository, IApplicationRepository applicationRepository)
        {
            this.studentRepository = studentRepository;
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

        public async Task<PaginatedList<GetApplicationDto>> Handle(GetStudentApplicationsQuery query, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(query.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {query.StudentId}");
            }

            var applications = await applicationRepository.GetStudentApplications(query.StudentId, query);

            return new PaginatedList<GetApplicationDto>(applications.Items.Select(mapper.Map<GetApplicationDto>).ToList(), query.Page, query.PageSize, applications.TotalCount);
        }
    }
}
