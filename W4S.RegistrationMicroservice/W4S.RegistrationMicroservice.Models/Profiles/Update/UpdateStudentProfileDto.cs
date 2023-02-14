using Microsoft.AspNetCore.Http;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateStudentProfileDto : UpdateProfileDto
    {
        public IFormFile? ResumeFile { get; set; }
        public List<ScheduleProfile>? Avaiability { get; set; }
    }
}
