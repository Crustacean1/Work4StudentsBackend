﻿namespace W4SRegistrationMicroservice.API.Models.Users.Creation
{
    public class AdministratorRegistrationDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}