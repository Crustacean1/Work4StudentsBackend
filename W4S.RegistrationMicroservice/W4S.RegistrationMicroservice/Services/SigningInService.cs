using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4S.RegistrationMicroservice.Models.Users.Signing;
using W4S.RegistrationMicroservice.Data.DbContexts;
using System.Security.Claims;
using W4SRegistrationMicroservice.API.Validations.UserAuthentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Signing;
using System;
using W4S.RegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.API.Services
{
    public class SigningInService : ISigningInService
    {
        private readonly UserbaseDbContext _dbContext;
        private readonly IHasher _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly ILogger<SigningInService> _logger;

        public SigningInService(
            IHasher passwordHasher,
            IOptions<AuthenticationSettings> authenticationSettings,
            UserbaseDbContext dbContext,
            ILogger<SigningInService> logger)
        {
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings.Value;
            _dbContext = dbContext;
            _logger = logger;
        }

        public UserSigningResponse SignIn(UserCredentialsDto userCredentialsDto)
        {
            var guid = ValidateCredentials(userCredentialsDto.EmailAddress, userCredentialsDto.Password);
            var signingResponse = new UserSigningResponse();

            _logger.LogInformation($"Created JWT token for {userCredentialsDto.EmailAddress}.");

            signingResponse.UserEmail = userCredentialsDto.EmailAddress;
            signingResponse.UserId = guid;
            signingResponse.JwtTokenValue = GenerateJwt(userCredentialsDto);
            signingResponse.UserType = CheckUserType(guid);

            Guid? profileGuid = _dbContext.StudentProfiles.Where(x => x.StudentId == guid).FirstOrDefault()?.Id;

            if(profileGuid == null)
            {
                profileGuid = _dbContext.EmployerProfiles.Where(x => x.EmployerId == guid).FirstOrDefault()?.Id;
            }

            _logger.LogInformation($"Profile id is {profileGuid}");
            signingResponse.UserProfileId = profileGuid;

            return signingResponse;
        }

        private Guid ValidateCredentials(string email, string password)
        {
            try
            {
                var emailAndPassword = _dbContext.Users
                    .Select(x => new { x.EmailAddress, x.PasswordHash, x.Id })
                    .First(x => x.EmailAddress == email);
                _logger.LogInformation("Found corresponding email and password.");

                if (!emailAndPassword.PasswordHash.Equals(_passwordHasher.HashText(password)))
                {
                    throw new Exception("Invalid password");// It's bad practice to throw exception and catch it right away...
                }

                return emailAndPassword.Id;
            }
            catch (Exception e)
            {
                throw new UserNotFoundException("Given credentials could not be verified.", e);
            }
        }

        private int CheckUserType(Guid guid)
        {
            var student = _dbContext.Students.Where(s => s.Id == guid).FirstOrDefault();
            if (student != null)
            {
                return 0;
            }

            var employer = _dbContext.Employers.Where(e => e.Id == guid).FirstOrDefault();

            if (employer != null)
            {
                return 1;
            }

            var admin = _dbContext.Administrators.Where(a => a.Id == guid).FirstOrDefault();
            if (admin != null)
            {
                return 2;
            }

            return 3;
        }

        private string GenerateJwt(UserCredentialsDto userCredentialsDto)
        {
            var user = _dbContext.Users
                .Select(x => new { x.Id, x.EmailAddress, x.Role })
                .Where(x => x.EmailAddress == userCredentialsDto.EmailAddress)
                .First();

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.EmailAddress}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Description}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
