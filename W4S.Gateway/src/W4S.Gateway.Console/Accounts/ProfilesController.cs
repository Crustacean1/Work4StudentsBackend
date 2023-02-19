using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Deleting;
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

        [HttpGet("get/studentByStudentId/{studentId}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(GetStudentProfileResponse)))]
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

        [HttpGet("get/employerByEmployerId/{employerId}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(GetEmployerProfileResponse)))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(StudentProfileUpdatedResponse)))]
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
                resume = new byte[dto.ResumeFile.Length];
                fileStream.Read(resume, 0, (int)dto.ResumeFile.Length);
            }

            var correctedDto = new UpdateStudentProfileDtoWithId()
            {
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                Surname = dto.Surname,
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

        [HttpPut("update/student/{id}/correctedFiles")]
        [Authorize(Roles = "Student,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(StudentProfileUpdatedResponse)))]
        public async Task<IActionResult> UpdateStudentProfileWithCorrectedPhotosAndResumes([FromRoute] Guid id, [FromForm] UpdateStudentProfileDto dto, CancellationToken cancellationToken)
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
                resume = new byte[dto.ResumeFile.Length];
                fileStream.Read(resume, 0, (int)dto.ResumeFile.Length);
            }

            var correctedDto = new UpdateStudentProfileDtoWithId()
            {
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                Surname = dto.Surname,
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
            var response = await busClient.SendRequest<StudentProfileUpdatedResponse, UpdateStudentProfileDtoWithId>("profiles.update.student.v2", correctedDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPut("update/employer/{id}")]
        [Authorize(Roles = "Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(EmployerProfileUpdatedResponse)))]
        public async Task<IActionResult> UpdateEmployerProfile([FromRoute] Guid id, [FromForm] UpdateEmployerProfileDto dto, CancellationToken cancellationToken)
        {
            byte[]? image = null;

            if (dto.Image != null)
            {
                using var fileStream = dto.Image.OpenReadStream();
                image = new byte[dto.Image.Length];
                fileStream.Read(image, 0, (int)dto.Image.Length);
            }

            var correctedDto = new UpdateEmployerProfileDtoWithId()
            {
                Id = id,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                Surname = dto.Surname,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = image,
                PositionName = dto.PositionName
            };
            logger.LogInformation("Request: Update employer profile");
            var response = await busClient.SendRequest<EmployerProfileUpdatedResponse, UpdateEmployerProfileDtoWithId>("profiles.update.employer", correctedDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpPut("update/employer/{id}/correctedFiles")]
        [Authorize(Roles = "Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(EmployerProfileUpdatedResponse)))]
        public async Task<IActionResult> UpdateEmployerProfileWithCorrectedPhotos([FromRoute] Guid id, [FromForm] UpdateEmployerProfileDto dto, CancellationToken cancellationToken)
        {
            byte[]? image = null;

            if (dto.Image != null)
            {
                using var fileStream = dto.Image.OpenReadStream();
                image = new byte[dto.Image.Length];
                fileStream.Read(image, 0, (int)dto.Image.Length);
            }

            var correctedDto = new UpdateEmployerProfileDtoWithId()
            {
                Id = id,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                Surname = dto.Surname,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = image,
                PositionName = dto.PositionName
            };
            logger.LogInformation("Request: Update employer profile");
            var response = await busClient.SendRequest<EmployerProfileUpdatedResponse, UpdateEmployerProfileDtoWithId>("profiles.update.employer.v2", correctedDto, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }

        [HttpGet("get/photo/{profileId:Guid}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(GetProfilePhotoResponse)))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(GetResumeResponse)))]
        public async Task<IActionResult> GetResumeByStudentId([FromRoute] Guid studentId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = studentId,
            };
            logger.LogInformation($"Request: Get resume of a student with Id: {studentId}.");

            var response = await busClient.SendRequest<GetResumeResponse, GuidPackedDto>("profiles.get.resume", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }


        [HttpDelete("resume/{studentId:Guid}")]
        [Authorize(Roles = "Student,Employer,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(StudentResumeDeletedResponse)))]
        public async Task<IActionResult> DeleteStudentResume([FromRoute] Guid studentId, CancellationToken cancellationToken)
        {
            var guid = new GuidPackedDto()
            {
                Id = studentId
            };
            logger.LogInformation($"Request: Delete resume of a student with Id: {studentId}.");

            var response = await busClient.SendRequest<StudentResumeDeletedResponse, GuidPackedDto>("profiles.delete.student.resume", guid, cancellationToken);

            if (response.ExceptionMessage is null)
            {
                return Ok(response);
            }
            return BadRequest(response.ExceptionMessage);
        }
    }
}
