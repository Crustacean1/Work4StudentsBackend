using Microsoft.AspNetCore.Http;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateEmployerProfileDto
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Surname { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? PositionName { get; set;}
    }
}
