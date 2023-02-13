using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles
{
    public class EmployerRatingChangedEvent
    {
        public Guid EmployerId { get; set; }
        public decimal Rating { get; set; }
    }
}
