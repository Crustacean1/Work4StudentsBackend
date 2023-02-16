using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting;
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

        [HttpGet("get/student/{id}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [Obsolete]
        public async Task<IActionResult> GetStudentProfileById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = id
            };
            logger.LogInformation($"Request: Get student profile with Id: {id}.");
            var response = await busClient.SendRequest<GetStudentProfileResponse, GuidPackedDto>("profiles.get.student", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpGet("get/studentByStudentId/{studentId}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        public async Task<IActionResult> GetStudentProfileByStudentId([FromRoute] Guid studentId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = studentId
            };
            logger.LogInformation($"Request: Get student profile with Id: {studentId}.");
            var response = await busClient.SendRequest<GetStudentProfileResponse, GuidPackedDto>("profiles.get.student.studentId", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpGet("get/employer/{id}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [Obsolete]
        public async Task<IActionResult> GetEmployerProfileById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = id
            };
            logger.LogInformation($"Request: Get employer profile with Id: {id}.");
            var response = await busClient.SendRequest<GetEmployerProfileResponse, GuidPackedDto>("profiles.get.employer", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpGet("get/employerByEmployerId/{employerId}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        public async Task<IActionResult> GetEmployerProfileByEmployerId([FromRoute] Guid employerId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = employerId
            };
            logger.LogInformation($"Request: Get employer profile with Id: {employerId}.");
            var response = await busClient.SendRequest<GetEmployerProfileResponse, GuidPackedDto>("profiles.get.employer.employerId", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpPut("update/student/{id}")]
        [Authorize(Roles = "Student,Administrator")]
        public async Task<IActionResult> UpdateStudentProfile([FromRoute] Guid id, [FromForm] UpdateStudentProfileDto dto, CancellationToken cancellationToken)
        {
            byte[]? image = null;
            byte[]? resume = null;

            if (dto.Image != null)
            {
                using var fileStream = dto.Image.OpenReadStream();
                image = new byte[dto.Image.Length];
                fileStream.Read(image, 0, (int)dto.Image.Length);
            }
            if (dto.ResumeFile != null)
            {
                using var fileStream = dto.ResumeFile.OpenReadStream();
                resume = new byte[dto.Image.Length];
                fileStream.Read(resume, 0, (int)dto.Image.Length);
            }

            var correctedDto = new UpdateStudentProfileDtoWithId()
            {
                Id = id,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description,
                Education = dto.Education,
                Experience = dto.Experience,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = image,
                ResumeFile = resume,
                Availability = dto.Availability
            };
            logger.LogInformation("Request: Update student profile");
            var response = await busClient.SendRequest<StudentProfileUpdatedResponse, UpdateStudentProfileDtoWithId>("profiles.update.student", correctedDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpPut("update/employer/{id}")]
        [Authorize(Roles = "Employer,Administrator")]
        public async Task<IActionResult> UpdateEmployerProfile([FromRoute] Guid id, [FromForm] UpdateProfileDto dto, CancellationToken cancellationToken)
        {
            byte[]? image = null;

            if (dto.Image != null)
            {
                using var fileStream = dto.Image.OpenReadStream();
                image = new byte[dto.Image.Length];
                fileStream.Read(image, 0, (int)dto.Image.Length);
            }

            var correctedDto = new UpdateProfileDtoWithId()
            {
                Id = id,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = image
            };
            logger.LogInformation("Request: Update employer profile");
            var response = await busClient.SendRequest<EmployerProfileUpdatedResponse, UpdateProfileDtoWithId>("profiles.update.employer", correctedDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpGet("get/photo/{profileId:Guid}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        public async Task<IActionResult> GetPhotoByProfileId([FromRoute] Guid profileId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = profileId,
            };
            logger.LogInformation($"Request: Get photo with Id: {profileId}.");

            var response = await busClient.SendRequest<GetProfilePhotoResponse, GuidPackedDto>("profiles.get.photo", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpGet("get/resume/{studentId:Guid}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        public async Task<IActionResult> GetResumeByStudentId([FromRoute] Guid studentId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = studentId,
            };
            logger.LogInformation($"Request: Get resume with Id: {studentId}.");

            var response = await busClient.SendRequest<GetProfilePhotoResponse, GuidPackedDto>("profiles.get.resume", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

    }
}
