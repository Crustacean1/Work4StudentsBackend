using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.RegistrationMicroservice.Data.Entities.Users;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    [Table("EmployerProfiles")]
    public class EmployerProfile : Profile
    {
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
