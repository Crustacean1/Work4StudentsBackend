using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateProfileCommandHandler : CommandHandlerBase, IRequestHandler<UpdateProfileCommand, Unit>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public UpdateProfileCommandHandler(IRepository<Student> studentRepository, IRepository<Recruiter> recruiterRepository)
        {
            this.studentRepository = studentRepository;
            this.recruiterRepository = recruiterRepository;

            var mapperConfig = new MapperConfiguration(b =>
            {
                b.CreateMap<UpdateProfileCommand, Profile>();
                //b.CreateMap<UpdateProfileCommand, Address>();
            });
            mapper = mapperConfig.CreateMapper();
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

            mapper.Map(request.ProfileEvent, user);
            return Unit.Value;
        }
    }
}
