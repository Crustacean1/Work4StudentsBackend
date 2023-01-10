﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.RegistrationMicroservice.Models.ServiceBusResponses.Users.Registration;
using W4S.RegistrationMicroservice.Models.Users.Creation;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Attributes;
using W4SRegistrationMicroservice.API.Interfaces;


namespace W4SRegistrationMicroservice.API.Controllers
{
    [BusService("registration")]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;
        private readonly IClient _busClient;

        public RegistrationController(
            IRegistrationService registrationService,
            IClient client) 
        { 
            _registrationService = registrationService;
            _busClient = client;
        }

        [BusRequestHandler("student")]
        public StudentRegisteredResponse RegisterStudent([FromBody] StudentRegistrationDto dto)
        {
            var response = new StudentRegisteredResponse();

            try
            {
                var eventAndId = _registrationService.RegisterStudent(dto);
                _busClient.SendEvent("registeredStudent", eventAndId.Item2);
                response.Id = eventAndId.Item1;
            }
            catch(Exception ex)
            {
                response.ExceptionMessage = ex.Message;
            }

            return response;
        }

        [BusRequestHandler("employer")]
        public EmployerRegisteredResponse RegisterEmployer([FromBody] EmployerRegistrationDto dto)
        {
            var response = new EmployerRegisteredResponse();

            try
            {
                var eventAndId = _registrationService.RegisterEmployer(dto);
                _busClient.SendEvent("registeredEmployer", eventAndId.Item2);
                response.Id = eventAndId.Item1;
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
            }

            return response;
        }
    }
}
