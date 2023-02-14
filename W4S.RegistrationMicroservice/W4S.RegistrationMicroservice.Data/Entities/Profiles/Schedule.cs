using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    public class StudentSchedule
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
    }
}
