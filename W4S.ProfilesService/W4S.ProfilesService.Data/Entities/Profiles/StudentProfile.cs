using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.ProfilesService.Data.Entities.Users;

namespace W4S.ProfilesService.Data.Entities.Profiles
{
    public class StudentProfile : Profile
    {
        public byte[]? ResumeFile { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
