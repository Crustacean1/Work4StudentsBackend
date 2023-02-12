using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public class RegisterStudentCommand
    {
        public StudentRegisteredEvent Student { get; set; }
    }
}
