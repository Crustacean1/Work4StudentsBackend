using W4SRegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities;
using System.Net.Mail;
using System.Text.RegularExpressions;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.API.Exceptions;

namespace W4S.RegistrationMicroservice.API.Services
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

        public EmployerRegisteredEvent RegisterEmployer(EmployerRegistrationDto employerCreationDto)
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

            _logger.LogInformation($"Employer role id: {employer.RoleId}");

            _dbContext.Employers.Add(employer);



            _dbContext.SaveChanges();

            return new EmployerRegisteredEvent()
            {
                Id = employer.Id,
                Date = DateTime.Now,
                EmailAddress = employerCreationDto.EmailAddress,
                FirstName = employerCreationDto.FirstName,
                SecondName = employerCreationDto.SecondName,
                Surname = employerCreationDto.Surname,
                NIP = employerCreationDto.NIP,
                Name = employerCreationDto.CompanyName,
                CompanyId = companyId.Value,
                PhoneNumber = employerCreationDto.PhoneNumber
            };
        }

        public StudentRegisteredEvent RegisterStudent(StudentRegistrationDto studentCreationDto)
        {
            Guid? emailDomainId = null;

            try
            {
                ValidateEmailCorrectness(studentCreationDto.EmailAddress);
                emailDomainId = ValidateUniversity(studentCreationDto.EmailAddress);
                _logger.LogInformation($"Domain Id is: {emailDomainId}");
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
                _logger.LogInformation("Trying to find an university.");
                universityId = _dbContext.Universities
                    .Select(x => new { x.Id, x.EmailDomainId })
                    .First(e => e.EmailDomainId == emailDomainId).Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            _logger.LogInformation("Finding a role that matches Student role.");

            var roles = _dbContext.Roles.ToList();

            foreach (var role in roles)
            {
                _logger.LogInformation($"Role with id: {role.Id} is named: {role.Description}.");
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

            try
            {
                _logger.LogInformation("Trying to add a student to the db.");
                _dbContext.Students.Add(student);

            }
            catch (Exception e)
            {
                _logger.LogError("Could not add a student. :---D");
                _logger.LogError(e.Message, e);
            }

            try
            {
                _logger.LogInformation("Trying to save changes.");
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not save changes.");
                _logger.LogError(e.Message, e);
            }

            var studentEvent = new StudentRegisteredEvent()
            {
                Id = student.Id,
                Date = DateTime.Now,
                FirstName = studentCreationDto.FirstName,
                SecondName = studentCreationDto.SecondName,
                Surname = studentCreationDto.Surname,
                EmailAddress = studentCreationDto.EmailAddress,
                UniversityDomain = _dbContext.UniversitiesDomains.Where(x => x.Id == emailDomainId).First().EmailDomain
            };

            if (studentEvent != null)
            {
                _logger.LogInformation("Student event is not null.");
            }
            else
            {
                _logger.LogInformation("Student event is null >:(");
            }

            return studentEvent;
        }


        // Checks if domain is present in the database, if yes -> return the id of it 
        private Guid ValidateUniversity(string studentEmail)
        {
            try
            {
                var domain = CheckDomain(studentEmail);

                return _dbContext.UniversitiesDomains
                    .First(x => x.EmailDomain.Equals(domain)).Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new UniversityDomainNotInDatabaseException("The domain in the email address is not a valid university domain.");
            }
        }

        private void ValidateEmailCorrectness(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

            try
            {
                if(_dbContext.Users.Any(e => e.EmailAddress == email))
                {
                    throw new UserAlreadyRegisteredException("This email is already connected to an another user.");
                }
            }
            catch (UserAlreadyRegisteredException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

        }

        private void ValidateNIPNumber(string nipNumber)
        {
            _logger.LogInformation($"Checking NIP number {nipNumber}");
            nipNumber = nipNumber.Replace("-", string.Empty);

            if (nipNumber.Length != 10 || nipNumber.Any(chr => !Char.IsDigit(chr)))
                throw new IncorrectNIPNumberException("NIP number is not supposed to have non-digit characters.");

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };
            int sum = nipNumber.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

            if((sum % 11) != (nipNumber[9] - '0')){
                throw new IncorrectNIPNumberException("This is not a valid NIP number.");
            }
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
