using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.Users.Creation;

namespace W4SRegistrationMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService) 
        { 
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("Student")]
        public IActionResult RegisterStudent([FromBody] StudentRegistrationDto dto)
        {
            try
            {
                _registrationService.RegisterStudent(dto);
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Employer")]
        public IActionResult RegisterEmployer([FromBody] EmployerRegistrationDto dto)
        {
            try
            {
                _registrationService.RegisterEmployer(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok();
        }
    }
}
