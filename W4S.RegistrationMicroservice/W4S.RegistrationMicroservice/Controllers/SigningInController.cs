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
                response = _signingInService.SignIn(credentialsDto);
            }
            catch (UserNotFoundException ex)
            {
                string message = string.Empty;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }
    }
}
