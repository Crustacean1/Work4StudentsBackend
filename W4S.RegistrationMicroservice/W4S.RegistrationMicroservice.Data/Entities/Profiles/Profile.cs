using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Data.Entities.Profiles
{
    public class Profile
    {
        public Guid Id { get; set; }
        public byte[]? Image { get; set; } // blob, if null -> some default photo, maybe make this a different entity with an corresponding id
        public string? Description { get; set; }
    }
}
