using W4S.RegistrationMicroservice.Models.Users.Signing;
using W4S.ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing;

namespace W4SRegistrationMicroservice.API.Controllers
{
    [BusService("signing")]
    public class SigningInController
    {
        private readonly ISigningInService _signingInService;
        private readonly ILogger<SigningInController> _logger;

        public SigningInController(
            ISigningInService signingInService,
            ILogger<SigningInController> logger)
        {
            _signingInService = signingInService;
            _logger = logger;
        }

        [BusRequestHandler("signin")]
        public Task<UserSigningResponse> SignIn(UserCredentialsDto credentialsDto)
        {
            _logger.LogInformation($"Got signing message from: {credentialsDto.EmailAddress}");
            var response = new UserSigningResponse();

            try
            {
                response.JwtTokenValue = _signingInService.SignIn(credentialsDto);
                response.UserEmail = credentialsDto.EmailAddress;
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                response.ExceptionMessage = ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}
