using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing;
using W4S.RegistrationMicroservice.Models.Users.Signing;

namespace W4SRegistrationMicroservice.API.Interfaces
{
    public interface ISigningInService
    {
        UserSigningResponse SignIn(UserCredentialsDto userCredentialsDto);
    }
}