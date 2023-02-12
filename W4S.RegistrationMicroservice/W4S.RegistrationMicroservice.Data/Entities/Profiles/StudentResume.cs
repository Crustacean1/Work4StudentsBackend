using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    public class StudentResume
    {
        public Guid Id { get; set; }
        public byte[]? ResumeFile { get; set; }
    }
}
