using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class StudentRegisteredEvent : BaseRegistrationEvent
    {
        public string UniversityDomain { get; set; }
    }
}
