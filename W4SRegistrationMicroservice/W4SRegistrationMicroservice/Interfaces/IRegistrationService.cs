using W4SRegistrationMicroservice.API.Models.Users.Creation;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface IRegistrationService
    {
        void RegisterStudent(StudentRegistrationDto studentCreationDto);
        void RegisterEmployer(EmployerRegistrationDto employerCreationDto);
    }
}
