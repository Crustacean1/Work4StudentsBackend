using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Models.Entities;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Models;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Updating;
using W4S.RegistrationMicroservice.Models.Users;
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
        public Task<StudentProfileUpdatedResponse> UpdateStudentProfile(UpdateStudentProfileDtoWithId correctedDto)
        {
            var response = new StudentProfileUpdatedResponse();

            try
            {
                _profilesService.UpdateStudentProfile(correctedDto);
                _logger.LogInformation($"Updated profile with Id {correctedDto.Id}.");
            }
            catch (Exception ex)
            {
                var message = ex?.InnerException?.Message ?? ex.Message;
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("update.employer")]
        public Task<EmployerProfileUpdatedResponse> UpdateEmployerProfile(UpdateEmployerProfileDtoWithId correctedDto)
        {
            var response = new EmployerProfileUpdatedResponse();

            _logger.LogInformation($"Got a request to update a profile with Id: {correctedDto.Id}");

            try
            {
                _profilesService.UpdateEmployerProfile(correctedDto);
                _logger.LogInformation($"Updated profile with Id {correctedDto.Id}.");
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex?.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }

            return Task.FromResult(response);
        }

        [BusRequestHandler("get.student")]
        [Obsolete]
        public Task GetStudentProfile(GuidPackedDto guid)
        {
            var response = new GetStudentProfileResponse();

            try
            {
                var profile = _profilesService.GetStudentProfile(guid.Id);

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

                if (profile.PhotoFile != null)
                {
                    response.Photo = Convert.ToBase64String(profile.PhotoFile);
                }
                if (profile.ResumeFile != null)
                {
                    response.Resume = Convert.ToBase64String(profile.ResumeFile);
                }

                //response.Availability = profile.Avaiability; 
            }
            catch (Exception ex)
            {
                var message = ex?.InnerException.Message ?? ex.Message;
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

                response.ProfileId = profile.Id;
                response.FirstName = profile.Student.Name;
                response.SecondName = profile.Student.SecondName ?? "";
                response.Surname = profile.Student.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber ?? "";
                response.StudentId = profile.StudentId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                if (profile.PhotoFile != null)
                {
                    response.Photo = Convert.ToBase64String(profile.PhotoFile);
                }
                else
                {
                    response.Photo = "";
                }
                if (profile.ResumeFile != null)
                {
                    response.Resume = Convert.ToBase64String(profile.ResumeFile);
                }
                else
                {
                    response.Resume = "";
                }
                response.Description = profile.Description ?? "";
                response.Education = profile.Education ?? "";
                response.Experience = profile.Experience ?? "";

                if (profile.Avaiability != null)
                {
                    var availability = new List<Schedule>();
                    foreach (var schedule in profile.Avaiability)
                    {
                        availability.Add(new Schedule()
                        {
                            DayOfWeek = schedule.DayOfWeek,
                            StartHour = schedule.StartHour,
                            Duration = schedule.Duration,
                        });
                    }
                    response.Availability = availability;
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
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

                response.ProfileId = profile.Id;
                response.FirstName = profile.Employer.Name;
                response.SecondName = profile.Employer.SecondName ?? "";
                response.Description = profile.Description ?? "";
                response.Surname = profile.Employer.Surname;
                response.EmailAddress = profile.EmailAddress;
                response.PhoneNumber = profile.PhoneNumber ?? "";
                response.EmployerId = profile.EmployerId;
                response.Rating = profile.Rating;
                response.Country = profile.Country;
                response.Region = profile.Region;
                response.City = profile.City;
                response.Street = profile.Street;
                response.Building = profile.Building;
                if (profile.PhotoFile != null)
                {
                    response.Photo = Convert.ToBase64String(profile.PhotoFile);
                }
                else
                {
                    response.Photo = "";
                }
                response.CompanyName = profile.CompanyName;
                response.PositionName = profile.PositionName;
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }


        [BusRequestHandler("get.photo")]
        public Task GetProfilePhotoById(GuidPackedDto guid)
        {
            var response = new GetProfilePhotoResponse(); // placeholder, getPhotoResponse
            try
            {
                var photo = _profilesService.GetUserPhoto(guid.Id);
                if (photo != null)
                {
                    response.Photo = Convert.ToBase64String(photo);
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.resume")]
        public Task GetResumeByStudentId(GuidPackedDto guid)
        {
            var response = new GetResumeResponse();
            try
            {
                var resume = _profilesService.GetStudentResume(guid.Id);
                if (resume != null)
                {
                    response.Resume = Convert.ToBase64String(resume);
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                _logger.LogError(message, ex);
                response.ExceptionMessage = message;
            }
            return Task.FromResult(response);
        }

        [BusRequestHandler("get.users")]
        public PaginatedList<UserDto> GetUsers(PaginatedQuery query)
        {
            _logger.LogInformation("Getting all users");
            return _profilesService.GetUsers(query);
        }

        [BusEventHandler("update.student.rating")]
        public void UpdateStudentRating(UserRatingChangedEvent changedEvent)
        {
            _logger.LogInformation($"Got an updated rating for the student with Id: {changedEvent.UserId}");
            _profilesService.UpdateStudentRating(changedEvent);
        }

        [BusEventHandler("update.employer.rating")]
        public void UpdateEmployerRating(UserRatingChangedEvent changedEvent)
        {
            _logger.LogInformation($"Got an updated rating for the student with Id: {changedEvent.UserId}");
            _profilesService.UpdateEmployerRating(changedEvent);
        }


    }
}
