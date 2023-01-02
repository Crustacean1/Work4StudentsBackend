using Gateway.Console.Microservices.Accounts.RequestDtos;
using Gateway.Console.Microservices.Accounts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Rabbit;
using System.Threading;

namespace Gateway.Console.Microservices.Accounts
{
    [Route("accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> logger;
        private readonly IClient busClient;

        public AccountsController(ILogger<AccountsController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPost("signing")]
        public async Task<IActionResult> SignIn([FromBody] UserCredentialsDto userCredentialsDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Sign in user");
            UserCredentialsResponse response = await busClient.SendRequest<UserCredentialsResponse, UserCredentialsDto>("signing.signin", userCredentialsDto, cancellationToken);

            if(response.ExceptionMessage is null) {
                return Ok(response.JwtTokenValue);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("registration/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDto registerStudentDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Register student");

            RegisterStudentResponse response = await busClient.SendRequest<RegisterStudentResponse, RegisterStudentDto>("registration.student", registerStudentDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok();
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("registration/employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] RegisterEmployerDto registerEmployerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Register employer");
            RegisterEmployerResponse response = await busClient.SendRequest<RegisterEmployerResponse, RegisterEmployerDto>("registration.employer", registerEmployerDto, cancellationToken);
            
            if(response.ExceptionMessage is null)
            {
                return Ok();
            }
            return BadRequest(response.ExceptionMessage);
        }

    }
}
