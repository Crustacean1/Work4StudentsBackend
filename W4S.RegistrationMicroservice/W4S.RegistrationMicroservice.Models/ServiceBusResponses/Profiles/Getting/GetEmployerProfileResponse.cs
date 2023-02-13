using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting
{
    public class GetEmployerProfileResponse : BaseResponse
    {
        public Guid ProfileId { get; set; }
        public Guid EmployerId { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal Rating { get; set; }
        public byte[]? Photo { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
