namespace W4S.RegistrationMicroservice.Models.Users.Creation
{
    public class StudentRegistrationDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
