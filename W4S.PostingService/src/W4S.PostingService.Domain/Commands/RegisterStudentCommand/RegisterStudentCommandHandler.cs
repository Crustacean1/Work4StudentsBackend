using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
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

        public async Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var address = mapper.Map<Address>(request.Student);
            var student = mapper.Map<Student>(request.Student);

            student.Address = address;

            var prevStudent = await studentRepository.GetEntityAsync(student.Id);
            if (prevStudent != null)
            {
                throw new PostingException($"Student with id {student.Id} is already registered", 400);
            }

            await studentRepository.AddAsync(student);
            await studentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
