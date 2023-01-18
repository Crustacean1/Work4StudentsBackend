using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface IRegistrationService
    {
        Tuple<Guid, StudentRegisteredEvent> RegisterStudent(StudentRegistrationDto studentCreationDto);
        Tuple<Guid, EmployerRegisteredEvent> RegisterEmployer(EmployerRegistrationDto employerCreationDto);
    }
}
