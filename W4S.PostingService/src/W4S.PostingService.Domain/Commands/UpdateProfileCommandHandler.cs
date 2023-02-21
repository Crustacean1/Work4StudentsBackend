using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Entities;
using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateProfileCommandHandler : CommandHandlerBase, IRequestHandler<UpdateProfileCommand, Unit>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Company> companyRepository;
        private readonly ILogger<UpdateProfileCommandHandler> logger;
        private readonly AddressApi addressApi;
        private readonly IMapper mapper;

        public UpdateProfileCommandHandler(IRepository<Student> studentRepository, IRepository<Recruiter> recruiterRepository, AddressApi addressApi, ILogger<UpdateProfileCommandHandler> logger)
        {
            this.studentRepository = studentRepository;
            this.recruiterRepository = recruiterRepository;

            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<UserChangedEvent, Person>()
                    .ForMember(p => p.Id, opt => opt.Ignore())
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                b.CreateMap<UserChangedEvent, Address>();
                b.CreateMap<UserChangedEvent, Company>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Name, opt => opt.MapFrom(e => e.CompanyName));
            });
            mapper = mapperConfig.CreateMapper();
            this.addressApi = addressApi;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            Person? user = await studentRepository.GetEntityAsync(request.ProfileEvent.UserId);
            user ??= await recruiterRepository.GetEntityAsync(request.ProfileEvent.UserId);

            if (user is null)
            {
                throw new PostingException($"No user with id: {request.ProfileEvent.UserId}", 400);
            }

            foreach (var avail in request.ProfileEvent.Availability)
            {
                logger.LogInformation("HAAAAA: {avail} ", avail.Duration);
            }


            mapper.Map(request.ProfileEvent, user);
            mapper.Map(request.ProfileEvent, user.Address);

            if (user is Student student)
            {
                await addressApi.UpdateAddress(student.Address);
            }
            if (user is Recruiter recruiter)
            {
                var company = await companyRepository.GetEntityAsync(recruiter.CompanyId);
                mapper.Map(request.ProfileEvent, company);
            }

            logger.LogInformation("New Creds: {FirstName} {Country} {Street}", user.FirstName, user.Address.Country, user.Address.Street);

            await studentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
