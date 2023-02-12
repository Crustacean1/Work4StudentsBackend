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

        [BusRequestHandler("get.student")]
        public Task GetStudentProfile(Guid id)
        {
            return Task.FromResult(0);
        }


        [BusRequestHandler("get.students")]
        public Task GetStudentsProfiles(Guid[] ids)
        {
            return Task.FromResult(0);
        }


        [BusRequestHandler("get.employer")]
        public Task GetEmployerProfile(Guid id)
        {
            return Task.FromResult(0);
        }

        [BusRequestHandler("get.employers")]
        public Task GetEmployersProfiles(Guid[] id)
        {
            return Task.FromResult(0);
        }

        [BusEventHandler("update.student.rating")]
        public Task UpdateStudentRating(Guid studentId, decimal rating)
        {
            return Task.FromResult(0);
        }

        [BusEventHandler("update.employer.rating")]
        public Task UpdateEmployerRating(Guid employerId, decimal rating)
        {
            return Task.FromResult(0);
        }

    }
}
