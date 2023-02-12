using AutoMapper;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("registered")]
    public class ProfileIntegrationHandler
    {
        private readonly ILogger<ProfileIntegrationHandler> logger;
        private readonly RegisterStudentCommandHandler registerStudentCommandHandler;
        private readonly RegisterRecruiterCommandHandler registerRecruiterCommandHandler;

        public ProfileIntegrationHandler(ILogger<ProfileIntegrationHandler> logger, RegisterStudentCommandHandler registerStudentCommandHandler, RegisterRecruiterCommandHandler registerRecruiterCommandHandler)
        {
            this.logger = logger;
            logger.LogInformation("Integration handler created");

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentRegisteredEvent, Student>();
                cfg.CreateMap<EmployerRegisteredEvent, Recruiter>();
            });
            this.registerStudentCommandHandler = registerStudentCommandHandler;
            this.registerRecruiterCommandHandler = registerRecruiterCommandHandler;
        }

        [BusEventHandler("student")]
        public async Task OnStudentRegistration(StudentRegisteredEvent student)
        {
            logger.LogInformation("Adding new applicant with id: {Id}", student.Id);

            await registerStudentCommandHandler.HandleCommand(new RegisterStudentCommand { Student = student });
        }

        [BusEventHandler("employer")]
        public async Task OnEmployerRegistration(EmployerRegisteredEvent recruiter)
        {
            logger.LogInformation("Adding new employer with id: {Id} from company {CompanyId}", recruiter.Id, recruiter.Company.Id);

            await registerRecruiterCommandHandler.HandleCommand(new RegisterRecruiterCommand { Recruiter = recruiter });
        }
    }
}
