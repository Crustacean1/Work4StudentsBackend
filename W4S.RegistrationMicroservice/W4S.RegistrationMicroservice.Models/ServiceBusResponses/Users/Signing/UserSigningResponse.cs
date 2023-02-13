namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing
{
    public class UserSigningResponse : BaseResponse
    {
        public string? UserEmail { get; set; }
        public Guid UserId { get; set; }
        public int UserType { get; set; }
        public string? JwtTokenValue { get; set; }
    }
}
