using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface IRegistrationService
    {
        Tuple<long, StudentRegisteredEvent> RegisterStudent(StudentRegistrationDto studentCreationDto);
        Tuple<long, EmployerRegisteredEvent> RegisterEmployer(EmployerRegistrationDto employerCreationDto);
    }
}
