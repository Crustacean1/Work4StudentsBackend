using W4S.RegistrationMicroservice.Models.Users.Registration;

namespace W4S.RegistrationMicroservice.Models.Users.Creation
{
    public class EmployerRegistrationDto : BaseRegistrationDto
    {
        public string NIP { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
    }
}
