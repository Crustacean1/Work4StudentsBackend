namespace W4SRegistrationMicroservice.API.Validations.UserAuthentication
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public string JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
