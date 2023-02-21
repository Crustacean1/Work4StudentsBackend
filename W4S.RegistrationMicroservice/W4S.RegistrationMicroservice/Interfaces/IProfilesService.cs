using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Models.Events;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.Users;

namespace W4S.RegistrationMicroservice.API.Interfaces
{
    public interface IProfilesService
    {
        Guid CreateEmployerProfile(Employer employer, string companyName);
        Guid CreateStudentProfile(Student student);
        StudentProfile GetStudentProfile(Guid id);
        StudentProfile GetStudentProfileByStudentId(Guid studentId);
        void DeleteStudentResume(Guid studentId);
        byte[]? GetStudentResume(Guid profileId);
        byte[]? GetUserPhoto(Guid profileId);
        void UpdateEmployerProfile(UpdateEmployerProfileDtoWithId dto);
        void UpdateEmployerProfilePhotosCorrected(UpdateEmployerProfileDtoWithId dto);
        void UpdateEmployerRating(UserRatingChangedEvent changedEvent);
        void UpdateStudentProfile(UpdateStudentProfileDtoWithId dto);
        void UpdateStudentProfilePhotosResumesCorrected(UpdateStudentProfileDtoWithId dto);
        void UpdateStudentAvailability(UpdateStudentSchedule dto);
        void UpdateStudentRating(UserRatingChangedEvent changedEvent);
        EmployerProfile GetEmployerProfile(Guid id);
        EmployerProfile GetEmployerProfileByEmployerId(Guid employerId);
        PaginatedList<UserDto> GetUsers(PaginatedQuery query);
    }
}
