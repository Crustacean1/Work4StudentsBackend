namespace Gateway.Console.Microservices.Accounts.RequestDtos
{
    public class RegisterEmployerDto : BaseRegistrationDto
    {
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
    }
}
