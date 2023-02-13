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
        public byte[]? PhotoFile { get; set; }   // blob, if null -> some default photo, maybe make this a different entity with an corresponding id
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string EmailAddress { get; set; }    // on change -> validate and change corresponding user
        public string? PhoneNumber { get; set; }    // on change -> validate and change corresponding user
        public decimal Rating { get; set; }     // get from an endpoint, 0.0 by default
        public string Education { get; set; }   // hold as a csv?
        public string Experience { get; set; }  // hold as a csv? 

        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
