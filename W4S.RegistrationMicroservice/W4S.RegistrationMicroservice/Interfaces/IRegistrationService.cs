using W4SRegistrationMicroservice.API.Models.Users.Creation;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface IRegistrationService
    {
        long RegisterStudent(StudentRegistrationDto studentCreationDto);
        long RegisterEmployer(EmployerRegistrationDto employerCreationDto);
    }
}
