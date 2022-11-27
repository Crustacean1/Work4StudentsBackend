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
        [Route("register/Student")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentCreationDto dto)
        {
            try
            {
                await Task.Run(() => _registrationService.RegisterStudent(dto));
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("register/Employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerCreationDto dto)
        {
            try
            {
                await Task.Run(() => _registrationService.RegisterEmployer(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok();
        }
    }
}
