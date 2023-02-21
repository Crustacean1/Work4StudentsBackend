using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.PostingService.Models.Entities;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateStudentSchedule
    {
        public Guid StudentId { get; set; }
        public List<Schedule> Schedule { get; set; }
    }
}
