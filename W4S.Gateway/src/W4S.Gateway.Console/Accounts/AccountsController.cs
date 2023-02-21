using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using W4S.RegistrationMicroservice.Models.Users.Signing;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing;
using W4S.RegistrationMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Deleting;
using System.Security.Claims;
using W4S.RegistrationMicroservice.Models.Users;

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

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetUsers([FromQuery] PaginatedQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: get all users");
            PaginatedList<UserDto> response = await busClient.SendRequest<PaginatedList<UserDto>, PaginatedQuery>("profiles.get.users", query);

            return Ok(response);
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
        [Authorize(Roles = "Student,Employer,Administrator")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId, CancellationToken cancellationToken)
        {

            var currentUserId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No userId claim specified");
            var currentUserRole = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? throw new InvalidOperationException("No user role specified.");

            if (currentUserRole != "Administrator" && userId.ToString() != currentUserId)
            {
                return Forbid();
            }

            var guid = new GuidPackedDto()
            {
                Id = userId
            };

            UserDeletedResponse response = await busClient.SendRequest<UserDeletedResponse, GuidPackedDto>("deleting.user", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return NoContent();
            }
            return BadRequest(response.ExceptionMessage);
        }

    }
}
