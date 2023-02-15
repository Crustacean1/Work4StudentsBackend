using Microsoft.AspNetCore.Http;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateStudentProfileDto : UpdateProfileDto
    {
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public IFormFile? ResumeFile { get; set; }
        public List<ScheduleProfile>? Availability { get; set; }
    }
}
