using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.ServiceBusResponses.Users.Registration;
using W4SRegistrationMicroservice.API.Models.Users.Creation;

namespace W4SRegistrationMicroservice.API.Controllers
{
    [ServiceBusHandler("registration")]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService) 
        { 
            _registrationService = registrationService;
        }

        [ServiceBusMethod("student")]
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

        [ServiceBusMethod("employer")]
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
