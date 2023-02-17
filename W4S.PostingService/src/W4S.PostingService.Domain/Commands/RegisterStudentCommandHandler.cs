using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Entities;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public class RegisterStudentCommandHandler : CommandHandlerBase, IRequestHandler<RegisterStudentCommand, Unit>
    {
        private readonly IRepository<Student> studentRepository;
        private readonly AddressApi addressApi;
        private readonly ILogger<RegisterStudentCommandHandler> logger;
        private readonly IMapper mapper;

        public RegisterStudentCommandHandler(IRepository<Student> studentRepository, AddressApi addressApi, ILogger<RegisterStudentCommandHandler> logger)
        {
            var mapperConfig = new MapperConfiguration(builder =>
            {
                builder.CreateMap<StudentRegisteredEvent, Student>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
                builder.CreateMap<StudentRegisteredEvent, Address>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            });

            mapper = mapperConfig.CreateMapper();
            this.studentRepository = studentRepository;
            this.addressApi = addressApi;
            this.logger = logger;
        }

        public async Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Adding student {Id}", request.Student.Id);

            var address = mapper.Map<Address>(request.Student);
            var student = mapper.Map<Student>(request.Student);

            student.Address = address;

            var prevStudent = await studentRepository.GetEntityAsync(student.Id);
            if (prevStudent != null)
            {
                throw new PostingException($"Student with id {student.Id} is already registered", 400);
            }

            await addressApi.UpdateAddress(student.Address);

            await studentRepository.AddAsync(student);
            await studentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
