using Microsoft.EntityFrameworkCore;
using W4S.RegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.API.Extensions;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.API.Validations.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Updating;
using W4S.ServiceBus.Abstractions;
using W4SRegistrationMicroservice.API.Exceptions;

namespace W4S.RegistrationMicroservice.API.Services
{
    public class ProfilesService : IProfilesService
    {
        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger<ProfilesService> _logger;
        private readonly IDataValidator _dataValidator;
        private readonly IClient _client;

        public ProfilesService(
            UserbaseDbContext dbContext,
            ILogger<ProfilesService> logger,
            IDataValidator dataValidator,
            IClient client)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dataValidator = dataValidator;
            _client = client;
        }

        #region Students

        public Guid CreateStudentProfile(Student student)
        {
            _logger.LogInformation($"Creating a new profile for Student with Id: {student.Id}");


            var profile = new StudentProfile()
            {
                Id = Guid.NewGuid(),
                PhotoFile = null,
                Description = "",
                ShortDescription = "",
                EmailAddress = student.EmailAddress,
                PhoneNumber = student.PhoneNumber,
                Rating = 0.0m,
                Education = "",
                Experience = "",
                Country = student.Country,
                Region = student.Region,
                City = student.City,
                Street = student.Street,
                Building = student.Building,
                ResumeFile = null,
                StudentId = student.Id,
                Student = student
            };

            _logger.LogInformation($"Profile with an Id: {profile.Id} created.");

            try
            {
                _logger.LogInformation("Adding to the database...");
                _dbContext.StudentProfiles.Add(profile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong with adding to the db.");
                _logger.LogInformation(ex.Message, ex);
                throw;
            }

            return profile.Id;
        }

        public void UpdateStudentProfile(UpdateStudentProfileDtoWithId dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles // include photos, update photo and profile
                    .Where(p => p.Id == dto.Id)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a user with this Id.");
                _logger.LogError(ex.Message, ex);
            }

            if (studentProfile != null)
            {
                studentProfile.Description = dto.Description;
                if (dto.Image != null)
                {
                    studentProfile.PhotoFile = dto.Image.ExtractFileContent();
                }
                else
                {
                    studentProfile.PhotoFile = null;
                }

                if(dto.ResumeFile != null)
                {
                    studentProfile.ResumeFile = dto.ResumeFile.ExtractFileContent();
                }
                else
                {
                    studentProfile.ResumeFile = null;
                }

                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = studentProfile.StudentId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                };

                _client.SendEvent<UserInfoUpdatedEvent>("profiles.user.updated", newEvent);
            }
        }

        public void UpdateStudentRating(StudentRatingChangedEvent changedEvent)
        {
            var studentProfile = _dbContext.StudentProfiles.Where(x => x.StudentId == changedEvent.StudentId).FirstOrDefault();

            if (studentProfile == null)
            {
                throw new UserNotFoundException("There is no student with this Id connected to any profile.");
            }

            studentProfile.Rating = changedEvent.Rating;
            _dbContext.StudentProfiles.Update(studentProfile);
            _dbContext.SaveChanges();
        }

        public StudentProfile GetStudentProfile(Guid id)
        {
            _logger.LogInformation("Getting student profile from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.Id == id)
                    .First();
                _logger.LogInformation($"Found profile with id: {id}.");

                var student = _dbContext.Students
                    .Where(s => s.Id == studentProfile.StudentId)
                    .First();

                studentProfile.Student = student;

                return studentProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public StudentProfile GetStudentProfileByStudentId(Guid studentId)
        {

            _logger.LogInformation("Getting employer profile from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.StudentId == studentId)
                    .First();

                var student = _dbContext.Students
                    .Where(s => s.Id == studentProfile.StudentId)
                    .First();

                studentProfile.Student = student;
                return studentProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public List<StudentProfile> GetStudentProfiles(Guid[] ids) // this should return all users, but paginated
        {
            _logger.LogInformation("Getting student profiles from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => ids.Contains(p.Id));
                return studentProfile.ToList();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public byte[]? GetStudentResume(Guid profileId)
        {
            var resume = _dbContext.StudentProfiles
                .Where(r => r.Id == profileId)
                .FirstOrDefault()
                .ResumeFile;

            if (resume == null)
            {
                _logger.LogInformation("This resume is null.");
            }
            return resume;
        }

        #endregion

        #region Employer

        public Guid CreateEmployerProfile(Employer employer, string companyName)
        {
            try
            {
                CheckIfEntityProfileAlreadyExist(employer.Id);
            }
            catch (Exception)
            {
                throw;
            }

            _logger.LogInformation("Creating a new profile for Student with Id: ...");

            var profile = new EmployerProfile()
            {
                Id = Guid.NewGuid(),
                Description = "",
                ShortDescription = "",
                EmailAddress = employer.EmailAddress,
                PhoneNumber = employer.PhoneNumber,
                Rating = 0.0m,
                Education = "",
                Experience = "",
                Country = employer.Country,
                Region = employer.Region,
                City = employer.City,
                Street = employer.Street,
                Building = employer.Building,
                PositionName = employer.PositionName,
                CompanyName = companyName,
                EmployerId = employer.Id,
                Employer = employer
            };

            _logger.LogInformation($"Profile with an Id: {profile.Id} created.");

            try
            {
                _logger.LogInformation("Adding to the database...");
                _dbContext.EmployerProfiles.Add(profile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong with adding to the db.");
                _logger.LogInformation(ex.Message, ex);
                throw;
            }

            return profile.Id;
        }

        public void UpdateEmployerProfile(UpdateProfileDtoWithId dto)
        {
            var employerProfile = _dbContext.EmployerProfiles 
                    .Where(p => p.Id == dto.Id)
                    .FirstOrDefault();

            if (employerProfile != null)
            {
                if (employerProfile.EmailAddress != dto.EmailAddress || employerProfile.PhoneNumber != dto.PhoneNumber) 
                {
                    _dataValidator.ValidateEmailCorrectness(dto.EmailAddress);
                    _dataValidator.ValidatePhoneNumber(dto.PhoneNumber);
                    var employer = _dbContext.Employers
                        .Where(e => e.Id == employerProfile.EmployerId)
                        .FirstOrDefault();

                    if (employer == null)
                    {
                        throw new UserNotFoundException("Couldn't find an employer connected to that profile."); // not gonna happen
                    }

                    employer.EmailAddress = dto.EmailAddress;
                    employer.PhoneNumber = dto.PhoneNumber;
                    _dbContext.Employers.Update(employer);
                }
                employerProfile.Description = dto.Description;
                employerProfile.ShortDescription = dto.ShortDescription;
                employerProfile.EmailAddress = dto.EmailAddress;
                employerProfile.PhoneNumber = dto.PhoneNumber;

                if(dto.Image != null)
                {
                    employerProfile.PhotoFile = dto.Image.ExtractFileContent();
                }
                else
                {
                    employerProfile.PhotoFile = null;
                }


                _dbContext.EmployerProfiles.Update(employerProfile);
                _dbContext.SaveChanges(); 
                
                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = employerProfile.EmployerId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                };

                _client.SendEvent<UserInfoUpdatedEvent>("profiles.user.updated", newEvent);
            }
        }

        public void UpdateEmployerRating(EmployerRatingChangedEvent changedEvent)
        {
            var employerProfile = _dbContext.EmployerProfiles.Where(x => x.EmployerId == changedEvent.EmployerId).FirstOrDefault();

            if (employerProfile == null)
            {
                throw new UserNotFoundException("There is no employer with this Id connected to any profile.");
            }

            employerProfile.Rating = changedEvent.Rating;
            _dbContext.EmployerProfiles.Update(employerProfile);
            _dbContext.SaveChanges();
        }

        public EmployerProfile GetEmployerProfile(Guid id)
        {
            _logger.LogInformation("Getting employer profile from the database.");
            try
            {
                var employerProfile = _dbContext.EmployerProfiles
                    .Where(p => p.Id == id)
                    .First();

                var employer = _dbContext.Employers
                    .Where(s => s.Id == employerProfile.EmployerId)
                    .First();

                employerProfile.Employer = employer;
                return employerProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public EmployerProfile GetEmployerProfileByEmployerId(Guid employerId)
        {

            _logger.LogInformation("Getting employer profile from the database.");
            try
            {
                var employerProfile = _dbContext.EmployerProfiles
                    .Where(p => p.EmployerId == employerId)
                    .First();

                var employer = _dbContext.Employers
                    .Where(s => s.Id == employerProfile.EmployerId)
                    .First();

                employerProfile.Employer = employer;
                return employerProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public List<EmployerProfile> GetEmployerProfiles(Guid[] ids) // this should return all users, but paginated
        {
            _logger.LogInformation("Getting student profiles from the database.");
            try
            {
                var studentProfile = _dbContext.EmployerProfiles
                    .Where(p => ids.Contains(p.Id));
                return studentProfile.ToList();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        #endregion

        #region Common methods

        public byte[]? GetUserPhoto(Guid profileId)
        {
            var photo = _dbContext.Profiles
                .Where(p => p.Id == profileId)
                .FirstOrDefault().PhotoFile;

            if (photo == null)
            {
                _logger.LogInformation("This photo is null.");
            }
            return photo;
        }

        private void CheckIfEntityProfileAlreadyExist(Guid entityId)
        {
            _logger.LogInformation("Checking if a profile for this entity already exists.");

            if (_dbContext.StudentProfiles.Where(p => p.StudentId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
            else if (_dbContext.EmployerProfiles.Where(p => p.EmployerId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
        }

        #endregion
    }
}
