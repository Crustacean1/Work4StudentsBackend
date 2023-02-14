using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;


namespace W4S.RegistrationMicroservice.API.Controllers
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
                response.Id = registrationEvent.Id;

                _busClient.SendEvent("registration.student.registered", registrationEvent);

                _logger.LogInformation("Registered student with email {Email} and Id: {Id}",
                                       registrationEvent.EmailAddress,
                                       registrationEvent.Id);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError("Error during student registration: {Error}, {Exception}", message, ex);
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
                response.Id = registrationEvent.Id;

                _busClient.SendEvent("registration.employer.registered", registrationEvent);

                _logger.LogInformation("Registered employer with email {Email} and Id: {Id}",
                                       registrationEvent.EmailAddress,
                                       registrationEvent.Id);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError("Error during employer registration: {Error}, {Exception}", message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }
    }
}
