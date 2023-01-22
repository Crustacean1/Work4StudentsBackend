using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Updating;
using W4S.ServiceBus.Abstractions;

namespace W4S.Gateway.Console.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ILogger<ProfilesController> logger;
        private readonly IClient busClient;

        public ProfilesController(ILogger<ProfilesController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPost("create/student")]
        [Authorize(Roles = "Student,Administrator")]
        public async Task<IActionResult> CreateStudentProfile([FromForm] CreateStudentProfileDto dto)
        {
            logger.LogInformation("Request: Create student profile");
            var response = await busClient.SendRequest<StudentProfileCreatedResponse, CreateStudentProfileDto>("profiles.create.student", dto);

            if (response.ExceptionMessage is null)
            {
                return CreatedAtAction(nameof(CreateEmployerProfile), response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPost("create/employer")]
        [Authorize(Roles = "Employer,Administrator")]
        public async Task<IActionResult> CreateEmployerProfile([FromForm] CreateProfileDto dto)
        {
            logger.LogInformation("Request: Create employer profile");
            var response = await busClient.SendRequest<EmployerProfileCreatedResponse, CreateProfileDto>("profiles.create.employer", dto);

            if (response.ExceptionMessage is null)
            {
                return CreatedAtAction(nameof(CreateEmployerProfile), response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPut("update/student/{id}")]
        [Authorize(Roles ="Student,Administrator")]
        public async Task<IActionResult> UpdateStudentProfile([FromRoute] Guid id, [FromForm] UpdateStudentProfileDto dto)
        {
            logger.LogInformation("Request: Update student profile");
            var response = await busClient.SendRequest<StudentProfileUpdatedResponse, UpdateStudentProfileDto>("profiles.update.student", dto);

            if (response.ExceptionMessage is null)
            {
                return Ok(response.WasUpdated);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpPut("update/employer/{id}")]
        [Authorize(Roles = "Employer,Administrator")]
        public async Task<IActionResult> UpdateEmployerProfile([FromRoute] Guid id, [FromForm] UpdateProfileDto dto)
        {
            logger.LogInformation("Request: Update employer profile");
            var response = await busClient.SendRequest<EmployerProfileUpdatedResponse, UpdateProfileDto>("profiles.update.employer", dto);

            if (response.ExceptionMessage is null)
            {
                return Ok(response.WasUpdated);
            }
            return BadRequest(response.ExceptionMessage);
        }
    }
}
