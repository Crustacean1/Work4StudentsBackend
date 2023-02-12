using Azure;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;
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

        [BusRequestHandler("update.student")]
        public Task<StudentProfileUpdatedResponse> UpdateStudentProfile([FromQuery] Guid id, [FromBody] UpdateStudentProfileDto dto)
        {
            var response = new StudentProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateStudentProfile(id, dto);
                _logger.LogInformation($"Updated profile with Id {id}.");
                response.WasUpdated = true;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
                response.WasUpdated = false;
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
                response.WasUpdated = true;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
                response.WasUpdated = false;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("get.student")]
        public Task GetStudentProfile(Guid id)
        {
            var response = new EmployerProfileCreatedResponse(); // placeholder

            try
            {
                _profilesService.GetStudentProfile(id);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }


        [BusRequestHandler("get.students")]
        public Task GetStudentsProfiles(Guid[] ids)
        {
            var response = new EmployerProfileCreatedResponse(); // placeholder
            try
            {
                _profilesService.GetStudentProfiles(ids);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }


        [BusRequestHandler("get.employer")]
        public Task GetEmployerProfile(Guid id)
        {
            var response = new EmployerProfileCreatedResponse(); // placeholder
            try
            {
                _profilesService.GetEmployerProfile(id);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.employers")]
        public Task GetEmployersProfiles(Guid[] ids)
        {
            var response = new EmployerProfileCreatedResponse(); // placeholder
            try
            {
                _profilesService.GetEmployerProfiles(ids);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusEventHandler("update.student.rating")]
        public void UpdateStudentRating(StudentRatingChangedEvent changedEvent)
        {
            _logger.LogInformation($"Got an updated rating for the student with Id: {changedEvent.StudentId}");
            _profilesService.UpdateStudentRating(changedEvent);
        }

        [BusEventHandler("update.employer.rating")]
        public void UpdateEmployerRating(EmployerRatingChangedEvent changedEvent)
        {
            _logger.LogInformation($"Got an updated rating for the student with Id: {changedEvent.EmployerId}");
            _profilesService.UpdateEmployerRating(changedEvent);
        }

    }
}
