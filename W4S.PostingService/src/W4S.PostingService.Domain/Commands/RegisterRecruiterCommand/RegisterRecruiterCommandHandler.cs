using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public class RegisterRecruiterCommandHandler : CommandHandlerBase, IRequestHandler<RegisterRecruiterCommand, Unit>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Company> companyRepository;
        private IMapper mapper;

        public RegisterRecruiterCommandHandler(IRepository<Recruiter> recruiterRepository, IRepository<Company> companyRepository)
        {
            var mapperConfig = new MapperConfiguration(builder =>
            {
                builder.CreateMap<EmployerRegisteredEvent, Recruiter>();
                builder.CreateMap<CompanyDto, Company>();
            });

            mapper = mapperConfig.CreateMapper();
            this.recruiterRepository = recruiterRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(RegisterRecruiterCommand command, CancellationToken cancellationToken)
        {
            var recruiter = mapper.Map<Recruiter>(command.Recruiter);
            var company = mapper.Map<Company>(command.Recruiter.Company);

            recruiter.Company = null!;
            recruiter.CompanyId = company.Id;

            _ = await GetEntity(recruiterRepository, recruiter.Id);
            _ = await GetEntity(companyRepository, company.Id);

            await recruiterRepository.AddAsync(recruiter);
            await recruiterRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
