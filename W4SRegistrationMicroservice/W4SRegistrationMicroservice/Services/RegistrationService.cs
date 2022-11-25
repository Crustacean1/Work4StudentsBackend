using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.Users;
using W4SRegistrationMicroservice.Data.DbContexts;

namespace W4SRegistrationMicroservice.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly W4SUserbaseDbContext _dbContext;

        public RegistrationService(W4SUserbaseDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public void RegisterStudent(StudentCreationDto studentCreationDto)
        {
            try
            {
                ValidateUniversity();
            }
            catch(UniversityDomainNotInDatabaseException ex)
            {
                throw;
            }
        }

        private void ValidateUniversity()
        {
            throw new UniversityDomainNotInDatabaseException("The domain in the email address is not a valid university domain.");
        }
    }
}
