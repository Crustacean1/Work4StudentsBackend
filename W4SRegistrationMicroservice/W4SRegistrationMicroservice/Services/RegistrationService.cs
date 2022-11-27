using System.Text;
using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.Users.Creation;
using W4SRegistrationMicroservice.Data.DbContexts;
using W4SRegistrationMicroservice.Data.Entities.Users;
using System.Security.Cryptography;
using W4SRegistrationMicroservice.Data.Entities;

namespace W4SRegistrationMicroservice.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly W4SUserbaseDbContext _dbContext;
        private readonly ILogger _logger;

        public RegistrationService(
            W4SUserbaseDbContext dbContext,
            ILogger<RegistrationService> logger) { 
            _dbContext = dbContext;
            _logger = logger;
        }

        public void RegisterEmployer(EmployerCreationDto employerCreationDto)
        {
            try
            {
                ValidateNIPNumber(employerCreationDto.NIP);
            }
            catch (IncorrectNIPNumberException e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            long? companyId = null;

            try
            {
                companyId = _dbContext.Companies
                    .Select(c => new { c.Id, c.NIP })
                    .First(c => c.NIP.Equals(employerCreationDto.NIP)).Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if(companyId == null)
            {
                var company = new Company() { 
                    Id = 0,
                    Name = employerCreationDto.CompanyName,
                    NIP = employerCreationDto.NIP
                };

                _dbContext.Add(company);
                _dbContext.SaveChanges();

                try
                {
                    companyId = _dbContext.Companies
                        .Select(c => new { c.Id, c.NIP })
                        .First(c => c.NIP.Equals(employerCreationDto.NIP)).Id;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            }

            var employer = new Employer()
            {
                Id = 0,
                EmailAddress = employerCreationDto.EmailAddress,
                PasswordHash = HashPassword(employerCreationDto.Password),
                Name = employerCreationDto.FirstName,
                Surname = employerCreationDto.Surname,
                PositionName = employerCreationDto.PositionName,
                CompanyId = companyId.Value
            };

            _dbContext.Employers.Add(employer);
            _dbContext.SaveChanges();
        }

        public void RegisterStudent(StudentCreationDto studentCreationDto)
        {
            try
            {
                ValidateUniversity(studentCreationDto.EmailAddress);
            }
            catch(UniversityDomainNotInDatabaseException e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            long? universityId = null;

            try
            {
                //universityId = _dbContext.Universities.Select // need to add Domain entity to Db
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            var student = new Student()
            {
                Id = 0,
                EmailAddress = studentCreationDto.EmailAddress,
                Name = studentCreationDto.FirstName,
                Surname = studentCreationDto.Surname,
                PasswordHash = HashPassword(studentCreationDto.Password)
                //UniversityId = 
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        private void ValidateUniversity(string studentEmail)
        {
            _logger.LogInformation($"{studentEmail} email temp validation.");
            //throw new UniversityDomainNotInDatabaseException("The domain in the email address is not a valid university domain.");
        }

        private void ValidateNIPNumber(string nipNumber)
        {
            _logger.LogInformation($"{nipNumber} NIP temp validation.");
            //throw new IncorrectNIPNumberException("The NIP number is incorrect.");
        }

        private string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 hashstring = SHA256.Create())
            {
                byte[] hash = hashstring.ComputeHash(bytes);
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
