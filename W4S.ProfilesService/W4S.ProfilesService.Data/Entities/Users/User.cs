using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.ProfilesService.Data.Entities.Users
{
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
