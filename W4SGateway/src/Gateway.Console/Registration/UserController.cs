using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;

namespace Gateway.Console.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IClient busClient;
        private readonly ILogger<UserController> logger;

        public UserController(IClient busClient, ILogger<UserController> logger)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPut]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegistrationDto registrationDto)
        {
            var result = await busClient.SendRequest<UserRegistrationResponse, UserRegistrationDto>("registration.student", registrationDto);
            return Ok(result);
        }
    }
}
