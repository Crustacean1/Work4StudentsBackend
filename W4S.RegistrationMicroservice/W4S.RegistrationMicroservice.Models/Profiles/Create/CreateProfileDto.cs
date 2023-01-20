using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.Profiles.Create
{
    public class CreateProfileDto
    {
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

    }
}
