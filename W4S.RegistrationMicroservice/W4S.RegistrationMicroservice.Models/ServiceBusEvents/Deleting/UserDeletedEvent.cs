using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Deleting
{
    public class UserDeletedEvent
    {
        public Guid UserId { get; set; }
    }
}
