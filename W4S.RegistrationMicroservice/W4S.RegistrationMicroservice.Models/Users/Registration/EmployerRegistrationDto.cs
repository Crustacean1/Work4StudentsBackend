using W4S.RegistrationMicroservice.Models.Users.Registration;

namespace W4S.RegistrationMicroservice.Models.Users.Creation
{
    public class EmployerRegistrationDto : BaseRegistrationDto
    {
        public string PositionName { get; set; }
        public string NIP { get; set; }
    }
}
