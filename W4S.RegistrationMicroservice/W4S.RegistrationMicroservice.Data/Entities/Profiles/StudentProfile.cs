using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.RegistrationMicroservice.Data.Entities.Users;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    [Table("StudentProfiles")]
    public class StudentProfile : Profile
    {
        public byte[]? ResumeFile { get; set; }
        public decimal Rating { get; set; } // calculated after every new rating
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
