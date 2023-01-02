namespace Gateway.Console.Microservices.Accounts.RequestDtos
{
    public class BaseRegistrationDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
