using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.ProfilesService.Data.Entities.Workplaces;

namespace W4S.ProfilesService.Data.Entities.Users
{
    public class Employer : User
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string PositionName { get; set; }
    }
}
