using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;


namespace W4SRegistrationMicroservice.API.Controllers
{
    [BusService("registration")]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;
        private readonly IClient _busClient;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(
            IRegistrationService registrationService,
            IClient client,
            ILogger<RegistrationController> logger)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
            _busClient = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BusRequestHandler("student")]
        public Task<StudentRegisteredResponse> RegisterStudent([FromBody] StudentRegistrationDto dto)
        {
            var response = new StudentRegisteredResponse();

            try
            {
                var registrationEvent = _registrationService.RegisterStudent(dto);
                _logger.LogInformation("User registered.");

                _busClient.SendEvent("registered.student", registrationEvent);
                response.Id = registrationEvent.Id;

                _logger.LogInformation("Event registered.student sent.");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("employer")]
        public Task<EmployerRegisteredResponse> RegisterEmployer([FromBody] EmployerRegistrationDto dto)
        {
            var response = new EmployerRegisteredResponse();

            try
            {
                var registrationEvent = _registrationService.RegisterEmployer(dto);
                _busClient.SendEvent("registered.employer", registrationEvent);
                response.Id = registrationEvent.Id;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }
    }
}
