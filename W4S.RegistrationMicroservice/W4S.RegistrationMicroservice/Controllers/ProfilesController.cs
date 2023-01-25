using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Updating;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;

namespace W4S.RegistrationMicroservice.API.Controllers
{
    [BusService("profiles")]
    public class ProfilesController
    {
        private readonly IProfilesService _profilesService;
        private readonly IClient _busClient;
        private readonly ILogger<ProfilesController> _logger;

        public ProfilesController(
            IProfilesService profilesService, 
            IClient busClient, 
            ILogger<ProfilesController> logger)
        {
            _profilesService = profilesService ?? throw new ArgumentNullException(nameof(profilesService));
            _busClient = busClient ?? throw new ArgumentNullException(nameof(profilesService));
            _logger = logger ?? throw new ArgumentNullException(nameof(profilesService));
        }

        [BusRequestHandler("create.student")]
        public Task<StudentProfileCreatedResponse> CreateStudentProfile([FromBody] CreateStudentProfileDto dto)
        {
            var response = new StudentProfileCreatedResponse();

            try
            {
                var profileId = _profilesService.CreateStudentProfile(dto);
                response.Id = profileId;
                _logger.LogInformation($"Profile with Id {profileId} created.");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("create.employer")]
        public Task<EmployerProfileCreatedResponse> CreateEmployerProfile([FromBody] CreateProfileDto dto)
        {
            var response = new EmployerProfileCreatedResponse();

            try
            {
                var profileId = _profilesService.CreateEmployerProfile(dto);
                _logger.LogInformation($"Profile with Id {profileId} created.");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("update.student")]
        public Task<StudentProfileUpdatedResponse> UpdateStudentProfile([FromQuery] Guid id, [FromBody] UpdateStudentProfileDto dto)
        {
            var response = new StudentProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateStudentProfile(id, dto);
                _logger.LogInformation($"Updated profile with Id {id}.");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("update.employer")]
        public Task<EmployerProfileUpdatedResponse> UpdateEmployerProfile([FromQuery] Guid id, [FromBody] UpdateProfileDto dto)
        {
            var response = new EmployerProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateEmployerProfile(id, dto);
                _logger.LogInformation($"Updated profile with Id {id}.");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }
    }
}
