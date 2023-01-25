using AutoMapper;
using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Entities;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("registered")]
    public class ProfileIntegrationHandler
    {
        private readonly ILogger<ProfileIntegrationHandler> logger;
        private readonly IProfileIntegrationService integrationService;
        private readonly IMapper mapper;

        public ProfileIntegrationHandler(ILogger<ProfileIntegrationHandler> logger, IProfileIntegrationService integrationService)
        {
            this.logger = logger;
            this.integrationService = integrationService;
            logger.LogInformation("Integration handler created");

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentRegisteredEvent, Applicant>();
                cfg.CreateMap<EmployerRegisteredEvent, Recruiter>();
            });
            mapper = mapperConfig.CreateMapper();
        }

        [BusEventHandler("student")]
        public async Task OnStudentRegistration(StudentRegisteredEvent registrationEvent)
        {
            logger.LogInformation("Adding new applicant with id: {Id}", registrationEvent.Id);

            var applicant = mapper.Map<Applicant>(registrationEvent);
            await integrationService.UpdateApplicant(applicant);
        }

        [BusEventHandler("employer")]
        public async Task OnEmployerRegistration(EmployerRegisteredEvent registrationEvent)
        {
            logger.LogInformation("Adding new employer with id: {Id}", registrationEvent.Id);
            var recruiter = mapper.Map<Recruiter>(registrationEvent);
            await integrationService.UpdateRecruiter(recruiter);
        }
    }
}
