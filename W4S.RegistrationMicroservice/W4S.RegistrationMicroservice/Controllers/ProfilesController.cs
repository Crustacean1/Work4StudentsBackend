using Azure;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting;
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
            var correctedDto = new UpdateStudentProfileDtoWithId()
            {
                Id = id,
                Description = dto.Description,
                ShortDescription = dto.ShortDescription,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Education = dto.Education,
                Experience = dto.Experience,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = dto.Image,
                ResumeFile = dto.ResumeFile,
            };

            var response = new StudentProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateStudentProfile(correctedDto);
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
            var correctedDto = new UpdateProfileDtoWithId()
            {
                Id = id,
                Description = dto.Description,
                ShortDescription = dto.ShortDescription,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Education = dto.Education,
                Experience = dto.Experience,
                Country = dto.Country,
                Region = dto.Region,
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Image = dto.Image,
            };

            var response = new EmployerProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateEmployerProfile(correctedDto);
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
        public Task GetStudentProfile(GuidPackedDto guid)
        {
            var response = new GetStudentProfileResponse();

            try
            {
                var profile = _profilesService.GetStudentProfile(guid.Id);

                if(profile.Student is null)
                {
                    _logger.LogInformation("This profile has student set as null.");
                }

                response.FirstName = profile.Student.Name;
                response.SecondName = profile.Student.SecondName;
                response.Surname = profile.Student.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber;
                response.StudentId = profile.StudentId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                response.Photo = profile.PhotoFile;
                response.Resume = profile.ResumeFile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.student.studentId")]
        public Task GetStudentProfileByStudentId(GuidPackedDto studentId)
        {
            var response = new GetStudentProfileResponse();

            try
            {
                var profile = _profilesService.GetStudentProfileByStudentId(studentId.Id);

                if (profile.Student is null)
                {
                    _logger.LogInformation("This profile has student set as null.");
                }

                response.FirstName = profile.Student.Name;
                response.SecondName = profile.Student.SecondName;
                response.Surname = profile.Student.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber;
                response.StudentId = profile.StudentId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                response.Photo = profile.PhotoFile;
                response.Resume = profile.ResumeFile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }


        //[BusRequestHandler("get.students")]
        //public Task GetStudentsProfiles(GuidPackedDtoList ids)
        //{
        //    var response = new EmployerProfileCreatedResponse(); // placeholder
        //    try
        //    {
        //        _profilesService.GetStudentProfiles(ids.PackedGuids.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.InnerException.Message ?? ex.Message;
        //        _logger.LogError(message, ex);
        //        response.ExceptionMessage = message;
        //    }
        //    return Task.FromResult(response);
        //}


        [BusRequestHandler("get.employer")]
        public Task GetEmployerProfile(GuidPackedDto employerId)
        {
            var response = new GetEmployerProfileResponse(); // placeholder
            try
            {
                var profile = _profilesService.GetEmployerProfile(employerId.Id);

                response.FirstName = profile.Employer.Name;
                response.SecondName = profile.Employer.SecondName;
                response.Surname = profile.Employer.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber;
                response.EmployerId = profile.EmployerId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                response.Photo = profile.PhotoFile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.employer.employerId")]
        public Task GetEmployerProfileByEmployerId(GuidPackedDto guid)
        {
            var response = new GetEmployerProfileResponse(); // placeholder
            try
            {
                var profile = _profilesService.GetEmployerProfileByEmployerId(guid.Id);

                response.FirstName = profile.Employer.Name;
                response.SecondName = profile.Employer.SecondName;
                response.Surname = profile.Employer.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber;
                response.EmployerId = profile.EmployerId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                response.Photo = profile.PhotoFile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        //[BusRequestHandler("get.employers")]
        //public Task GetEmployersProfiles(GuidPackedDtoList ids)
        //{
        //    var response = new EmployerProfileCreatedResponse(); // placeholder
        //    try
        //    {
        //        var profile = _profilesService.GetEmployerProfiles(ids.PackedGuids.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.InnerException.Message ?? ex.Message;
        //        _logger.LogError(message, ex);
        //        response.ExceptionMessage = message;
        //    }
        //    return Task.FromResult(response);
        //}


        [BusRequestHandler("get.photo")]
        public Task GetProfilePhotoById(GuidPackedDto guid)
        {
            var response = new GetProfilePhotoResponse(); // placeholder, getPhotoResponse
            try
            {
                var photo = _profilesService.GetUserPhoto(guid.Id);
                response.Photo = photo;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.resume")]
        public Task GetResumeById(GuidPackedDto guid)
        {
            var response = new GetResumeResponse(); // placeholder, getResumeResponse
            try
            {
                var resume = _profilesService.GetStudentResume(guid.Id);
                response.Resume = resume;
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
