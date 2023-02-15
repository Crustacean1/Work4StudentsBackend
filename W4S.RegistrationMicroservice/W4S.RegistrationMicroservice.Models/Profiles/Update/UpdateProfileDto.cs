using Microsoft.AspNetCore.Http;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateProfileDto
    {
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
