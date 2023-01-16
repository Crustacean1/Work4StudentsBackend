using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.ProfilesService.Data.Entities.Users;

namespace W4S.ProfilesService.Data.Entities.Profiles
{
    public class EmployerProfile : Profile
    {
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
