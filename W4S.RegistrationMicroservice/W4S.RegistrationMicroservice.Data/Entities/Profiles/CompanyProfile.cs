using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.RegistrationMicroservice.Data.Entities.Users;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    public class CompanyProfile : Profile // implement
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
