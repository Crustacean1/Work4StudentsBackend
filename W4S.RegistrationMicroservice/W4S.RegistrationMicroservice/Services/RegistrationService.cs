﻿using W4S.RegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.API.Validations.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Deleting;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Abstractions;
using W4SRegistrationMicroservice.CommonServices.Interfaces;

namespace W4S.RegistrationMicroservice.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IHasher _passwordHasher;
        private readonly IProfilesService _profilesService;

        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IDataValidator _dataValidator;
        private readonly IClient _busClient;

        public RegistrationService(
            IHasher passwordHasher,
            IProfilesService profilesService,
            UserbaseDbContext dbContext,
            ILogger<RegistrationService> logger,
            IDataValidator dataValidator,
            IClient busClient)
        {
            _passwordHasher = passwordHasher;
            _profilesService = profilesService;
            _dbContext = dbContext;
            _logger = logger;
            _dataValidator = dataValidator;
            _busClient = busClient;
        }

        public void DeleteUser(Guid userId)
        {
            try
            {
                var userToDelete = _dbContext.Users
                    .Where(x => x.Id == userId)
                    .First();

                _logger.LogInformation($"Found user with Id: {userId}");

                Guid? profileGuid = null;

                profileGuid = _dbContext.StudentProfiles
                    .Where(x => x.StudentId == userId)
                    .FirstOrDefault()?.Id;

                if(profileGuid == null)
                {
                    profileGuid = _dbContext.EmployerProfiles
                        .Where(x => x.EmployerId == userId)
                        .First().Id;
                }

                var profileToDelete = _dbContext.Profiles
                    .Where(x => x.Id == profileGuid)
                    .First();

                _logger.LogInformation($"Profile found with Id: {profileGuid}");

                _dbContext.Remove(userToDelete);
                _dbContext.Remove(profileToDelete);

                _logger.LogInformation("Trying to delete an user and his profile.");

                _dbContext.SaveChanges();

                _logger.LogInformation($"User with Id: {userId} and profile with Id: {profileGuid} has been deleted.");

                var userDeletedEvent = new UserDeletedEvent()
                {
                    UserId = userId
                };

                _busClient.SendEvent<UserDeletedEvent>("registration.user.deleted", userDeletedEvent);
            }
            catch(Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public EmployerRegisteredEvent RegisterEmployer(EmployerRegistrationDto employerCreationDto)
        {
            try
            {
                _dataValidator.ValidateEmailCorrectness(employerCreationDto.EmailAddress, null);
                _dataValidator.ValidateNIPNumber(employerCreationDto.NIP);
                if(employerCreationDto.PhoneNumber != null) 
                { 
                    //_dataValidator.ValidatePhoneNumber(employerCreationDto.PhoneNumber);
                }
            }
            catch (IncorrectNIPNumberException)
            {
                throw;
            }
            catch (UserAlreadyRegisteredException)
            {
                throw;
            }
            catch (IncorrectPhoneNumberException e)
            {
                var message = e.InnerException?.Message ?? e.Message;
                _logger.LogError(message, e);
                throw;
            }
            catch (FormatException e)
            {
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

                companyId = company.Id;
            }

            var employer = new Employer()
            {
                Id = Guid.NewGuid(),
                EmailAddress = employerCreationDto.EmailAddress,
                PhoneNumber = employerCreationDto.PhoneNumber,
                PasswordHash = _passwordHasher.HashText(employerCreationDto.Password),
                Name = employerCreationDto.FirstName,
                SecondName = employerCreationDto.SecondName,
                Surname = employerCreationDto.Surname,
                PositionName = employerCreationDto.PositionName,
                Country = employerCreationDto.Country,
                Region = employerCreationDto.Region,
                City = employerCreationDto.City,
                Street = employerCreationDto.Street,
                Building = employerCreationDto.Building,
                CompanyId = companyId.Value,
                RoleId = _dbContext.Roles.First(s => s.Description.Equals("Employer")).Id
            };

            try
            {
                _logger.LogInformation("Trying to add the employer to the db.");
                _dbContext.Employers.Add(employer);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not add the employer. :---D");
                _logger.LogError(e.Message, e);
                _logger.LogError(e.InnerException.Message, e);
            }

            _profilesService.CreateEmployerProfile(employer, employerCreationDto.CompanyName);

            return new EmployerRegisteredEvent()
            {
                Id = employer.Id,
                Date = DateTime.Now,
                EmailAddress = employerCreationDto.EmailAddress,
                FirstName = employerCreationDto.FirstName,
                SecondName = employerCreationDto.SecondName,
                Surname = employerCreationDto.Surname,
                NIP = employerCreationDto.NIP,
                Country = employerCreationDto.Country,
                Region = employerCreationDto.Region,
                City = employerCreationDto.City,
                Street = employerCreationDto.Street,
                Building = employerCreationDto.Building,
                PositionName = employerCreationDto.PositionName,
                CompanyId = companyId.Value,
                Company = new CompanyDto
                {
                    NIP = employerCreationDto.NIP,
                    Name = employerCreationDto.CompanyName,
                    Id = companyId.Value,
                },
                PhoneNumber = employerCreationDto.PhoneNumber
            };
        }

        public StudentRegisteredEvent RegisterStudent(StudentRegistrationDto studentCreationDto)
        {
            Guid? emailDomainId = null;

            try
            {
                _dataValidator.ValidateEmailCorrectness(studentCreationDto.EmailAddress, null);
                emailDomainId = _dataValidator.ValidateUniversity(studentCreationDto.EmailAddress);
                if(studentCreationDto.PhoneNumber != null)
                {
                    //_dataValidator.ValidatePhoneNumber(studentCreationDto.PhoneNumber);
                }
            }
            catch (UniversityDomainNotInDatabaseException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
            catch (IncorrectPhoneNumberException e)
            {
                _logger.LogError(e.Message);
                studentCreationDto.PhoneNumber = null;
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
                PhoneNumber = studentCreationDto.PhoneNumber,
                Name = studentCreationDto.FirstName,
                SecondName = studentCreationDto.SecondName,
                Surname = studentCreationDto.Surname,
                PasswordHash = _passwordHasher.HashText(studentCreationDto.Password),
                Country = studentCreationDto.Country,
                Region = studentCreationDto.Region,
                City = studentCreationDto.City,
                Street = studentCreationDto.Street,
                Building = studentCreationDto.Building,
                UniversityId = universityId.Value,
                RoleId = _dbContext.Roles.First(s => s.Description.Equals("Student")).Id
            };

            try
            {
                _logger.LogInformation("Trying to add the student to the db.");
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Added student with id: {student.Id}.");
            }
            catch (Exception e)
            {
                _logger.LogError("Could not add the student. :---D");
                _logger.LogError(e.Message, e);
                _logger.LogError(e.InnerException.Message, e);
            }

            _logger.LogInformation("Creating student profile.");

            _profilesService.CreateStudentProfile(student);

            var studentEvent = new StudentRegisteredEvent()
            {
                Id = student.Id,
                Date = DateTime.Now,
                FirstName = student.Name,
                SecondName = student.SecondName,
                Surname = student.Surname,
                EmailAddress = student.EmailAddress,
                UniversityDomain = _dbContext.UniversitiesDomains.Where(x => x.Id == emailDomainId).First().EmailDomain,
                PhoneNumber = student.PhoneNumber,
                Country = student.Country,
                Region = student.Region,
                City = student.City,
                Street = student.Street,
                Building = student.Building
            };

            return studentEvent;
        }
    }
}
