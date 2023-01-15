using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class BaseRegistrationEvent : BaseEvent
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
    }
}
