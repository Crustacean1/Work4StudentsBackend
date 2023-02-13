using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;

namespace W4S.RegistrationMicroservice.API.Interfaces
{
    public interface IProfilesService
    {
        Guid CreateEmployerProfile(Employer employer);
        Guid CreateStudentProfile(Student student);
        StudentProfile GetStudentProfile(Guid id);
        List<StudentProfile> GetStudentProfiles(Guid[] ids);
        byte[]? GetStudentResume(Guid resumeId);
        byte[]? GetUserPhoto(Guid photoId);
        void UpdateEmployerProfile(UpdateProfileDtoWithId dto);
        void UpdateEmployerRating(EmployerRatingChangedEvent changedEvent);
        void UpdateStudentProfile(UpdateStudentProfileDtoWithId dto);
        void UpdateStudentRating(StudentRatingChangedEvent changedEvent);
        EmployerProfile GetEmployerProfile(Guid id);
        List<EmployerProfile> GetEmployerProfiles(Guid[] ids);

    }
}