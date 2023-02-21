using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Deleting;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;

namespace W4S.RegistrationMicroservice.API.Controllers
{
    [BusService("deleting")]
    public class DeletingController
    {
        private readonly IRegistrationService _registrationService;
        private readonly IClient _busClient;
        private readonly ILogger<DeletingController> _logger;

        public DeletingController(
            IRegistrationService registrationService,
            IClient client,
            ILogger<DeletingController> logger)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
            _busClient = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [BusRequestHandler("user")]
        public Task<UserDeletedResponse> DeleteUser(GuidPackedDto guid)
        {
            var response = new UserDeletedResponse();

            try
            {
                _registrationService.DeleteUser(guid.Id);
            }
            catch(Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError("Error during user deleting: {Error}, {Exception}", message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }
    }
}
