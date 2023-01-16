using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities;
using System.Net.Mail;
using System.Text.RegularExpressions;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.RegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private const string REGEX_DOMAIN_PATTERN = @"@([\w\-]+)((\.(\w){2,3})+)$";

        private readonly IHasher _passwordHasher;

        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger _logger;

        public RegistrationService(
            IHasher passwordHasher,
            UserbaseDbContext dbContext,
            ILogger<RegistrationService> logger)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
            _logger = logger;
        }

        public Tuple<Guid, EmployerRegisteredEvent> RegisterEmployer(EmployerRegistrationDto employerCreationDto)
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

            Guid? companyId = null;

            try
            {
                companyId = _dbContext.Companies
                    .Select(c => new { c.Id, c.NIP })
                    .First(c => c.NIP.Equals(employerCreationDto.NIP)).Id;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }

            if (companyId == null)
            {
                var company = new Company()
                {
                    Id = Guid.NewGuid(),
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
                Id = Guid.NewGuid(),
                EmailAddress = employerCreationDto.EmailAddress,
                PasswordHash = _passwordHasher.HashText(employerCreationDto.Password),
                Name = employerCreationDto.FirstName,
                Surname = employerCreationDto.Surname,
                PositionName = employerCreationDto.PositionName,
                CompanyId = companyId.Value,
                RoleId = _dbContext.Roles.First(s => s.Description.Equals("Employer")).Id
            };

            _dbContext.Employers.Add(employer);
            _dbContext.SaveChanges();

            return Tuple.Create<Guid, EmployerRegisteredEvent>(
                _dbContext.Employers
                    .Where(x => x.Name.Equals(employer.Name)).First().Id,
                new EmployerRegisteredEvent()
                {
                    Date = DateTime.Now,
                    EmailAddress = employerCreationDto.EmailAddress,
                    FirstName = employerCreationDto.FirstName,
                    SecondName = employerCreationDto.SecondName,
                    Surname = employerCreationDto.Surname,
                    NIP = employerCreationDto.NIP,
                    CompanyName = employerCreationDto.CompanyName

                });
        }

        public Tuple<Guid, StudentRegisteredEvent> RegisterStudent(StudentRegistrationDto studentCreationDto)
        {
            Guid? emailDomainId = null;

            try
            {
                emailDomainId = ValidateUniversity(studentCreationDto.EmailAddress);
            }
            catch (UniversityDomainNotInDatabaseException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
            catch (FormatException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

            Guid? universityId = null;

            try
            {
                universityId = _dbContext.Universities
                    .Select(e => new { e.EmailDomainId, e.Id })
                    .First(e => e.EmailDomainId == emailDomainId).Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            var student = new Student()
            {
                Id = Guid.NewGuid(),
                EmailAddress = studentCreationDto.EmailAddress,
                Name = studentCreationDto.FirstName,
                Surname = studentCreationDto.Surname,
                PasswordHash = _passwordHasher.HashText(studentCreationDto.Password),
                UniversityId = universityId.Value,
                RoleId = _dbContext.Roles.First(s => s.Description.Equals("Student")).Id
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return Tuple.Create<Guid, StudentRegisteredEvent>(_dbContext.Students
                .Select(x => new { x.Name, x.Id })
                .Where(x => x.Name.Equals(student.EmailAddress)).First().Id,
                new StudentRegisteredEvent()
                {
                    Date = DateTime.Now,
                    FirstName = studentCreationDto.FirstName,
                    SecondName = studentCreationDto.SecondName,
                    Surname = studentCreationDto.Surname,
                    UniversityDomain = _dbContext.UniversitiesDomains.Where(x => x.Id == emailDomainId).First().EmailDomain
                });
        }


        // Checks if domain is present in the database, if yes -> return the id of it 
        private Guid ValidateUniversity(string studentEmail)
        {
            try
            {
                MailAddress mail = new MailAddress(studentEmail);
            }
            catch (FormatException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

            string domain = string.Empty;

            try
            {
                domain = CheckDomain(studentEmail);

                return _dbContext.UniversitiesDomains
                    .First(x => x.EmailDomain.Equals(domain)).Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new UniversityDomainNotInDatabaseException("The domain in the email address is not a valid university domain.");
            }
        }

        private void ValidateNIPNumber(string nipNumber)
        {
            //throw new IncorrectNIPNumberException("The NIP number is incorrect.");
        }

        private string CheckDomain(string studentEmail)
        {
            var regex = new Regex(REGEX_DOMAIN_PATTERN);

            var match = regex.Match(studentEmail);

            if (match.Success)
            {
                return match.Value;
            }
            throw new UniversityDomainNotInDatabaseException("This email has no valid domain.");
        }
    }
}
