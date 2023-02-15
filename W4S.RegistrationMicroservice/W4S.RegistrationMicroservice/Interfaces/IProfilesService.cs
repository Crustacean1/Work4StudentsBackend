using W4S.PostingService.Domain.Commands;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;

namespace W4S.RegistrationMicroservice.API.Interfaces
{
    public interface IProfilesService
    {
        Guid CreateEmployerProfile(Employer employer, string companyName);
        Guid CreateStudentProfile(Student student);
        StudentProfile GetStudentProfile(Guid id);
        StudentProfile GetStudentProfileByStudentId(Guid studentId);
        List<StudentProfile> GetStudentProfiles(Guid[] ids);
        byte[]? GetStudentResume(Guid profileId);
        byte[]? GetUserPhoto(Guid profileId);
        void UpdateEmployerProfile(UpdateProfileDtoWithId dto);
        void UpdateEmployerRating(UserRatingChangedEvent changedEvent);
        void UpdateStudentProfile(UpdateStudentProfileDtoWithId dto);
        void UpdateStudentRating(UserRatingChangedEvent changedEvent);
        EmployerProfile GetEmployerProfile(Guid id);
        EmployerProfile GetEmployerProfileByEmployerId(Guid employerId);
        List<EmployerProfile> GetEmployerProfiles(Guid[] ids);

    }
}