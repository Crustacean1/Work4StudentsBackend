using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("registration")]
    public class ProfileIntegrationHandler
    {
        private readonly ILogger<ProfileIntegrationHandler> logger;
        private readonly ISender sender;

        public ProfileIntegrationHandler(ILogger<ProfileIntegrationHandler> logger, ISender sender)
        {
            this.logger = logger;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentRegisteredEvent, Student>();
                cfg.CreateMap<EmployerRegisteredEvent, Recruiter>();
            });
            this.sender = sender;
        }

        [BusEventHandler("student.registered")]
        public async Task OnStudentRegistration(StudentRegisteredEvent student)
        {
            logger.LogInformation("Adding new applicant with id: {Id}", student.Id);

            await sender.Send(new RegisterStudentCommand { Student = student });
        }

        [BusEventHandler("employer.registered")]
        public async Task OnEmployerRegistration(EmployerRegisteredEvent recruiter)
        {
            logger.LogInformation("Adding new employer with id: {Id} from company {CompanyId}", recruiter.Id, recruiter.Company.Id);

            await sender.Send(new RegisterRecruiterCommand { Recruiter = recruiter });
        }

        [BusEventHandler("profiles.user.updated")]
        public async Task OnProfileUpdate(UserInfoUpdatedEvent updateEvent)
        {
            logger.LogInformation("Updating profile of user {User}", updateEvent.UserId);
            await sender.Send(new UpdateProfileCommand { ProfileEvent = updateEvent });
        }
    }
}
