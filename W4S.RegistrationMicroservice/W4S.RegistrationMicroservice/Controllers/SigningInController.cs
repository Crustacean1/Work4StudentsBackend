﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Exceptions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Models.ServiceBusResponses.Users.Signing;
using W4SRegistrationMicroservice.API.Models.Users.Signing;

namespace W4SRegistrationMicroservice.API.Controllers
{
    [BusService("signing")]
    public class SigningInController
    {
        private readonly ISigningInService _signingInService;
        private readonly ILogger<SigningInController> _logger;

        public SigningInController(
            ISigningInService signingInService,
            ILogger<SigningInController> logger)
        {
            _signingInService = signingInService;
            _logger = logger;
        }

        [BusRequestHandler("signin")]
        public UserSigningResponse SignIn(UserCredentialsDto credentialsDto)
        {
            _logger.LogInformation($"Got signing message from: {credentialsDto.EmailAddress}");
            var response = new UserSigningResponse();

            try
            {
                response.JwtTokenValue = _signingInService.SignIn(credentialsDto);
                response.UserEmail = credentialsDto.EmailAddress;
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                response.ExceptionMessage = ex.Message;
            }

            return response;
        }
    }
}