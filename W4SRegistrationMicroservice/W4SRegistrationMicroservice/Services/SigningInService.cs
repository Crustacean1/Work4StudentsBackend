using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4SRegistrationMicroservice.API.Models.Users.Enums;
using W4SRegistrationMicroservice.API.Models.Users.Signing;
using W4SRegistrationMicroservice.Data.DbContexts;
using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.API.Services
{
    public class SigningInService : ISigningInService
    {
        private readonly W4SUserbaseDbContext _dbContext;
        private readonly IHasher _passwordHasher;
        private readonly ILogger<SigningInService> _logger;

        public SigningInService(
            IHasher passwordHasher,
            W4SUserbaseDbContext dbContext,
            ILogger<SigningInService> logger)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
            _logger = logger;
        }

        public string SignIn(UserCredentialsDto userCredentialsDto)
        {
            switch (userCredentialsDto.UserRole)
            {
                case UserRoleEnum.Administrator:
                    try
                    {
                        ValidateCredentials(_dbContext.Administrators, userCredentialsDto.EmailAddress, userCredentialsDto.Password);
                    }
                    catch
                    {
                        throw;
                    }
                    break;
                case UserRoleEnum.Student:
                    try
                    {
                        ValidateCredentials(_dbContext.Students, userCredentialsDto.EmailAddress, userCredentialsDto.Password);
                    }
                    catch
                    {
                        throw;
                    }
                    break;
                case UserRoleEnum.Employer:
                    try
                    {
                        ValidateCredentials(_dbContext.Employers, userCredentialsDto.EmailAddress, userCredentialsDto.Password);
                    }
                    catch
                    {
                        throw;
                    }
                    break;
            }

            _logger.LogInformation($"Created JWT token for {userCredentialsDto.EmailAddress}.");
            return string.Empty;
        }

        private void ValidateCredentials(IEnumerable<User> dbSet, string email, string password)
        {
            try
            {
                dbSet
                    .Select(x => new { x.EmailAddress, x.PasswordHash })
                    .First(x => x.EmailAddress == email && x.PasswordHash == _passwordHasher.HashText(password));
            }
            catch
            {
                throw new UserNotFoundException("Given credentials could not be verified.");
            }
        }
    }
}
