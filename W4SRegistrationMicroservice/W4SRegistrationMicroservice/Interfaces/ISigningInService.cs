using W4SRegistrationMicroservice.API.Models.Users.Signing;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface ISigningInService
    {
        string SignIn(UserCredentialsDto userCredentialsDto);
    }
}