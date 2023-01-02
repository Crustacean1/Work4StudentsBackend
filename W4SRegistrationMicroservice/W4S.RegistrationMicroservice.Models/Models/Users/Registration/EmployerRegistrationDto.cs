namespace W4S.RegistrationMicroservice.Models.Users.Creation
{
    public class EmployerRegistrationDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
    }
}
