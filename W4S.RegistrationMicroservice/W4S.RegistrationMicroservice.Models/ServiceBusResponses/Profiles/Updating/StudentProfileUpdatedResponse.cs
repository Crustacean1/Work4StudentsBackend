using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Updating
{
    public class StudentProfileUpdatedResponse : BaseResponse
    {
        public bool? WasUpdated { get; set; }
    }
}
