using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Rabbit;
using System.Threading;
using W4S.RegistrationMicroservice.Models.Users.Signing;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4SRegistrationMicroservice.API.Models.ServiceBusResponses.Users.Signing;
using W4S.RegistrationMicroservice.Models.Users.Creation;

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
            UserSigningResponse response = await busClient.SendRequest<UserSigningResponse, UserCredentialsDto>("signing.signin", userCredentialsDto, cancellationToken);

            if(response.ExceptionMessage is null) {
                return Ok(response.JwtTokenValue);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("registration/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistrationDto registerStudentDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Register student");

            StudentRegisteredResponse response = await busClient.SendRequest<StudentRegisteredResponse, StudentRegistrationDto>("registration.student", registerStudentDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok();
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("registration/employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegistrationDto registerEmployerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Register employer");
            EmployerRegisteredResponse response = await busClient.SendRequest<EmployerRegisteredResponse, EmployerRegistrationDto>("registration.employer", registerEmployerDto, cancellationToken);
            
            if(response.ExceptionMessage is null)
            {
                return Ok();
            }
            return BadRequest(response.ExceptionMessage);
        }

    }
}
