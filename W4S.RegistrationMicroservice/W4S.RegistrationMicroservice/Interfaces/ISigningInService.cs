using W4S.RegistrationMicroservice.Models.Users.Signing;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface ISigningInService
    {
        string SignIn(UserCredentialsDto userCredentialsDto);
    }
}