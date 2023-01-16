using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.ProfilesService.Data.Entities.Profiles
{
    public class Profile : Entity
    {
        public byte[]? Image { get; set; } // blob, if null -> some default photo, maybe make this a different entity with an corresponding id
        public string Description { get; set; }
    }
}
