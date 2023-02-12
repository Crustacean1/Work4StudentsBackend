using W4S.RegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Models.Profiles.Create;
using W4S.RegistrationMicroservice.Models.Profiles.Update;

namespace W4S.RegistrationMicroservice.API.Services
{
    public class ProfilesService : IProfilesService
    {
        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger<ProfilesService> _logger;

        public ProfilesService(
            UserbaseDbContext dbContext,
            ILogger<ProfilesService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region Students

        public Guid CreateStudentProfile(CreateStudentProfileDto dto)
        {
            _logger.LogInformation("Creating a new profile for Student with Id: ...");

            var photo = new ProfilePhoto()
            {
                Id = Guid.NewGuid(),
                PhotoFile = dto.Image
            };

            var profile = new StudentProfile() // fill it with a dto
            {
                Id = Guid.NewGuid(),
                Description = dto.Description,
                PhotoId = photo.Id,
                ResumeFile = dto.ResumeFile,
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

        public void UpdateStudentProfile(Guid id, UpdateStudentProfileDto dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles // include photos, update photo and profile
                    .Where(p => p.Id == id)
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
                //studentProfile.Image = dto.Image;
                //studentProfile.ResumeFile = dto.ResumeFile;

                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();
            }
        }

        public StudentProfile GetStudentProfile(Guid id)
        {
            _logger.LogInformation("Getting student profile from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.Id == id)
                    .First();
                return studentProfile;
            }
            catch(Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public List<StudentProfile> GetStudentProfiles(Guid[] ids)
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

        #endregion

        #region Employer

        public Guid CreateEmployerProfile(CreateProfileDto dto)
        {
            try
            {
                CheckIfEntityProfileAlreadyExist(dto.UserId);
            }
            catch (Exception)
            {
                throw;
            }

            _logger.LogInformation("Creating a new profile for Student with Id: ...");

            var photo = new ProfilePhoto()
            {
                Id = Guid.NewGuid(),
                PhotoFile = dto.Image
            };

            var profile = new EmployerProfile() // fill it with a dto
            {
                Id = Guid.NewGuid(),
                Description = dto.Description,
                PhotoId = photo.Id,
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

        public void UpdateEmployerProfile(Guid Id, UpdateProfileDto dto) // UpdateStudentProfileDto
        {
            EmployerProfile? employerProfile = null;

            try
            {
                employerProfile = _dbContext.EmployerProfiles // include photos, update photo and profile
                    .Where(p => p.Id == Id)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a user with this Id.");
                _logger.LogError(ex.Message, ex);
            }

            if (employerProfile != null)
            {
                employerProfile.Description = dto.Description;
                //employerProfile.Image = dto.Image;

                _dbContext.EmployerProfiles.Update(employerProfile);
                _dbContext.SaveChanges();
            }
        }

        #endregion

        #region Common methods

        private void CheckIfEntityProfileAlreadyExist(Guid entityId)
        {
            _logger.LogInformation("Checking if a profile for this entity already exists.");

            if (_dbContext.StudentProfiles.Where(p => p.StudentId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
            else if(_dbContext.EmployerProfiles.Where(p => p.EmployerId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
        }

        #endregion
    }
}
