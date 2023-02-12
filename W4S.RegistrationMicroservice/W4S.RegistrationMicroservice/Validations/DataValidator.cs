﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using W4S.RegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.API.Validations.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;

namespace W4S.RegistrationMicroservice.Validations
{
    public class DataValidator : IDataValidator
    {
        private const string REGEX_DOMAIN_PATTERN = @"@([\w\-]+)((\.(\w){2,3})+)$";
        private const string REGEX_PHONE_NUMBER_PATTERN = @"";

        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger<DataValidator> _logger;

        public DataValidator(
            UserbaseDbContext context,
            ILogger<DataValidator> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public Guid ValidateUniversity(string studentEmail)
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

        public void ValidateEmailCorrectness(string email)
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
                if (_dbContext.Users.Any(e => e.EmailAddress == email))
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

        public void ValidateNIPNumber(string nipNumber)
        {
            _logger.LogInformation($"Checking NIP number {nipNumber}");
            nipNumber = nipNumber.Replace("-", string.Empty);

            if (nipNumber.Length != 10 || nipNumber.Any(chr => !Char.IsDigit(chr)))
                throw new IncorrectNIPNumberException("NIP number is not supposed to have non-digit characters.");

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };
            int sum = nipNumber.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

            if ((sum % 11) != (nipNumber[9] - '0'))
            {
                throw new IncorrectNIPNumberException("This is not a valid NIP number.");
            }
        }

        public void ValidatePhoneNumber(string phoneNumber)
        {

        }

        public string CheckDomain(string studentEmail)
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
