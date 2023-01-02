using W4S.RegistrationMicroservice.Models.ServiceBusResponses;

namespace W4SRegistrationMicroservice.API.Models.ServiceBusResponses.Users.Signing
{
    public class UserSigningResponse : BaseResponse
    {
        public string? UserEmail { get; set; }
        public string? JwtTokenValue { get; set; }
    }
}
