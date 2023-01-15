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

namespace W4SRegistrationMicroservice.API.Services
{
    public class SigningInService : ISigningInService
    {
        private readonly W4SUserbaseDbContext _dbContext;
        private readonly IHasher _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly ILogger<SigningInService> _logger;

        public SigningInService(
            IHasher passwordHasher,
            IOptions<AuthenticationSettings> authenticationSettings,
            W4SUserbaseDbContext dbContext,
            ILogger<SigningInService> logger)
        {
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings.Value;
            _dbContext = dbContext;
            _logger = logger;
        }

        public string SignIn(UserCredentialsDto userCredentialsDto)
        {
            ValidateCredentials(userCredentialsDto.EmailAddress, userCredentialsDto.Password);


            _logger.LogInformation($"Created JWT token for {userCredentialsDto.EmailAddress}.");
            return GenerateJwt(userCredentialsDto);
        }

        private void ValidateCredentials(string email, string password)
        {
            try
            {
                var emailAndPassword = _dbContext.Users
                    .Select(x => new { x.EmailAddress, x.PasswordHash })
                    .First(x => x.EmailAddress == email);
                _logger.LogInformation("Found corresponding email and password.");

                if (!emailAndPassword.PasswordHash.Equals(_passwordHasher.HashText(password)))
                {
                    throw new Exception("Invalid password");// It's bad practice to throw exception and catch it right away...
                }
            }
            catch(Exception e)
            {
                throw new UserNotFoundException("Given credentials could not be verified.", e);
            }
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
                new Claim(ClaimTypes.Role, $"{user.Role.Role}")
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
