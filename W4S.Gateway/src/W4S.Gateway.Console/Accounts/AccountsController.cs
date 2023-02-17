using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Rabbit;
using System.Threading;
using W4S.RegistrationMicroservice.Models.Users.Signing;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing;
using W4S.RegistrationMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Deleting;

namespace W4S.Gateway.Console.Accounts
{
    [Route("api/[controller]")]
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

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
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
                return Ok(response.Id);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("registration/employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegistrationDto registerEmployerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Register employer");
            EmployerRegisteredResponse response = await busClient.SendRequest<EmployerRegisteredResponse, EmployerRegistrationDto>("registration.employer", registerEmployerDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response.Id);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpDelete("user/{userId:Guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = userId
            };

            UserDeletedResponse response = await busClient.SendRequest<UserDeletedResponse, GuidPackedDto>("deleting.user", guid, cancellationToken);

            if(response.ExceptionMessage is null)
            {
                return NoContent();
            }
            return BadRequest(response.ExceptionMessage);
        }

    }
}
