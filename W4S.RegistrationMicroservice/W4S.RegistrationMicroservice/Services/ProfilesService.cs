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

        public Guid CreateStudentProfile(CreateStudentProfileDto dto) // CreateStudentProfileDto
        {
            _logger.LogInformation("Creating a new profile for Student with Id: ...");

            var profile = new StudentProfile() // fill it with a dto
            {
                Id = Guid.NewGuid(),
                Description = dto.Description,
                Image = dto.Image,
                ResumeFile = dto.ResumeFile,
                EntityId = dto.UserId
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

        public void UpdateStudentProfile(Guid Id, UpdateStudentProfileDto dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.Id == Id)
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
                studentProfile.Image = dto.Image;
                studentProfile.ResumeFile = dto.ResumeFile;

                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();
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

            var profile = new EmployerProfile() // fill it with a dto
            {
                Id = Guid.NewGuid(),
                Description = dto.Description,
                Image = dto.Image,
                EntityId = dto.UserId
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
                employerProfile = _dbContext.EmployerProfiles
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
                employerProfile.Image = dto.Image;

                _dbContext.EmployerProfiles.Update(employerProfile);
                _dbContext.SaveChanges();
            }
        }

        #endregion

        #region Common methods

        private void CheckIfEntityProfileAlreadyExist(Guid entityId)
        {
            _logger.LogInformation("Checking if a profile for this entity already exists.");

            if (_dbContext.Profiles.Where(p => p.EntityId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile  for this entity is already set up.");
            }
        }

        #endregion
    }
}
