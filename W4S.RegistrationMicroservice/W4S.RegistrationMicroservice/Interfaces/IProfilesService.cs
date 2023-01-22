using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;

namespace W4S.RegistrationMicroservice.API.Interfaces
{
    public interface IProfilesService
    {
        Guid CreateEmployerProfile(CreateProfileDto dto);
        Guid CreateStudentProfile(CreateStudentProfileDto dto);
        void UpdateEmployerProfile(Guid Id, UpdateProfileDto dto);
        void UpdateStudentProfile(Guid Id, UpdateStudentProfileDto dto);
    }
}