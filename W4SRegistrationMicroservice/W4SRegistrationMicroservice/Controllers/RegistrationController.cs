using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.ServiceBusResponses.Users.Registration;


namespace W4SRegistrationMicroservice.API.Controllers
{
    [BusService("registration")]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService) 
        { 
            _registrationService = registrationService;
        }

        [BusRequestHandler("student")]
        public StudentRegisteredResponse RegisterStudent([FromBody] StudentRegistrationDto dto)
        {
            var response = new StudentRegisteredResponse();

            try
            {
                response.Id = _registrationService.RegisterStudent(dto);
            }
            catch(Exception ex)
            {
                response.ExceptionMessage = ex.Message;
            }

            return response;
        }

        [BusRequestHandler("employer")]
        public EmployerRegisteredResponse RegisterEmployer([FromBody] EmployerRegistrationDto dto)
        {
            var response = new EmployerRegisteredResponse();

            try
            {
                 response.Id = _registrationService.RegisterEmployer(dto);
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
            }

            return response;
        }
    }
}
