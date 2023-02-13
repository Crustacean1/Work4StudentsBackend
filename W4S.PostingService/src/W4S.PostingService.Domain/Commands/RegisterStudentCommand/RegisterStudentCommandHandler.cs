using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public class RegisterStudentCommandHandler : CommandHandlerBase, IRequestHandler<RegisterStudentCommand, Unit>
    {
        private readonly IRepository<Student> studentRepository;
        private IMapper mapper;

        public RegisterStudentCommandHandler(IRepository<Student> studentRepository)
        {
            var mapperConfig = new MapperConfiguration(builder =>
            {
                builder.CreateMap<StudentRegisteredEvent, Student>();
                builder.CreateMap<StudentRegisteredEvent, Address>();
            });

            mapper = mapperConfig.CreateMapper();
            this.studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(RegisterStudentCommand command, CancellationToken cancellationToken)
        {
            var address = mapper.Map<Address>(command.Student);
            var student = mapper.Map<Student>(command.Student);

            student.Address = address;

            _ = await GetEntity(studentRepository, student.Id);

            await studentRepository.AddAsync(student);
            await studentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
