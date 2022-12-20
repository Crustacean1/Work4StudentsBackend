using W4SRegistrationMicroservice.API.Models.Users.Enums;

namespace W4SRegistrationMicroservice.API.Models.Users.Signing
{
    public class UserCredentialsDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public UserRoleEnum UserRole { get; set; }
    }
}
