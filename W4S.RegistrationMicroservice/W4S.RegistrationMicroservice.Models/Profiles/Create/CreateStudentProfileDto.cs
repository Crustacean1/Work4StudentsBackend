using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.Profiles.Create
{
    public class CreateStudentProfileDto : CreateProfileDto
    {
        public byte[]? ResumeFile { get; set; }
    }
}
