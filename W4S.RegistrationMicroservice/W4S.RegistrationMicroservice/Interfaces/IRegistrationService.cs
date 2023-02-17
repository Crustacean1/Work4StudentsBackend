using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.RegistrationMicroservice.API.Interfaces
{
    public interface IRegistrationService
    {
        StudentRegisteredEvent RegisterStudent(StudentRegistrationDto studentCreationDto);
        EmployerRegisteredEvent RegisterEmployer(EmployerRegistrationDto employerCreationDto);
        void DeleteUser(Guid userId);
    }
}
