using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Interfaces;


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
            _registrationService = registrationService;
            _busClient = client;
            _logger = logger;
        }

        [BusRequestHandler("student")]
        public Task<StudentRegisteredResponse> RegisterStudent([FromBody] StudentRegistrationDto dto)
        {
            var response = new StudentRegisteredResponse();

            try
            {
                var eventAndId = _registrationService.RegisterStudent(dto);
                _busClient.SendEvent("registeredStudent", eventAndId.Item2);
                response.Id = eventAndId.Item1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.ExceptionMessage = ex.Message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("employer")]
        public Task<EmployerRegisteredResponse> RegisterEmployer([FromBody] EmployerRegistrationDto dto)
        {
            var response = new EmployerRegisteredResponse();

            try
            {
                var eventAndId = _registrationService.RegisterEmployer(dto);
                _busClient.SendEvent("registeredEmployer", eventAndId.Item2);
                response.Id = eventAndId.Item1;
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}
