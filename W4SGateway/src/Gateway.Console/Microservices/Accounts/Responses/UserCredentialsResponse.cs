namespace Gateway.Console.Microservices.Accounts.Responses
{
    public class UserCredentialsResponse
    {
        public string? UserEmail { get; set; }
        public string? JwtTokenValue { get; set; }
        public string? ExceptionMessage { get; set; }
    }
}
