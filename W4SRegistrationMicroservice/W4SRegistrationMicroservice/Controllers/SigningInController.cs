using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.Users.Signing;

namespace W4SRegistrationMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigningInController : ControllerBase
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

        [HttpPost]
        public IActionResult SignIn(UserCredentialsDto credentialsDto)
        {
            try
            {
                return Ok(_signingInService.SignIn(credentialsDto));
            }
            catch(UserNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
