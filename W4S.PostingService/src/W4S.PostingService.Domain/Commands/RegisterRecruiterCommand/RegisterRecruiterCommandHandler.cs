using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
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
                builder.CreateMap<EmployerRegisteredEvent, Recruiter>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
                builder.CreateMap<CompanyDto, Company>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
                builder.CreateMap<EmployerRegisteredEvent, Address>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            });

            mapper = mapperConfig.CreateMapper();
            this.recruiterRepository = recruiterRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(RegisterRecruiterCommand command, CancellationToken cancellationToken)
        {
            var recruiter = mapper.Map<Recruiter>(command.Recruiter);
            var company = mapper.Map<Company>(command.Recruiter.Company);
            var address = mapper.Map<Address>(command.Recruiter);

            recruiter.Company = null;
            recruiter.CompanyId = company.Id;
            recruiter.Address = address;

            var prevStudent = await recruiterRepository.GetEntityAsync(recruiter.Id);
            if (prevStudent != null)
            {
                throw new PostingException($"Recruiter with id {recruiter.Id} is already registered", 400);
            }

            var prevCompany = await companyRepository.GetEntityAsync(company.Id);
            if (prevCompany is null)
            {
                await companyRepository.AddAsync(company);
            }

            await recruiterRepository.AddAsync(recruiter);
            await recruiterRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
