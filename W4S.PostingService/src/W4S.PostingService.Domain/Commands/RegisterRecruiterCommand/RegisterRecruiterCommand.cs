using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public class RegisterRecruiterCommand
    {
        public EmployerRegisteredEvent Recruiter { get; set; }
    }
}
