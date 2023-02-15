using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateProfileCommandHandler : CommandHandlerBase, IRequestHandler<UpdateProfileCommand, Unit>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly AddressApi addressApi;
        private readonly IMapper mapper;

        public UpdateProfileCommandHandler(IRepository<Student> studentRepository, IRepository<Recruiter> recruiterRepository, AddressApi addressApi)
        {
            this.studentRepository = studentRepository;
            this.recruiterRepository = recruiterRepository;

            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<UpdateProfileCommand, Person>()
                .ForMember(p => p.Id, opt => opt.Ignore());
                b.CreateMap<UpdateProfileCommand, Address>();
            });
            mapper = mapperConfig.CreateMapper();
            this.addressApi = addressApi;
        }

        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(request.ProfileEvent.UserId);
            var recruiter = await recruiterRepository.GetEntityAsync(request.ProfileEvent.UserId);

            var user = (Person?)student ?? recruiter;

            if (user is null)
            {
                throw new PostingException($"No user with id: {request.ProfileEvent.UserId}", 400);
            }

            if (student is not null)
            {
                await addressApi.UpdateAddress(student.Address);
            }

            mapper.Map(request.ProfileEvent, user);
            mapper.Map(request.ProfileEvent, user.Address);

            await studentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
