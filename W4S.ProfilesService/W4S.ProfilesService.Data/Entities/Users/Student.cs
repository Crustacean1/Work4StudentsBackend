using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.ProfilesService.Data.Entities.Workplaces;

namespace W4S.ProfilesService.Data.Entities.Users
{
    public class Student : User
    {
        public Guid UniversityId { get; set; }
        public University University { get; set; }
    }
}
