using W4S.PostingService.Models.Entities;
using W4S.RegistrationMicroservice.Models.Profiles;

namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting
{
    public class GetStudentProfileResponse : BaseResponse
    {
        public Guid ProfileId { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public decimal Rating { get; set; }
        public string? Photo { get; set; }
        public string? Resume { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public List<Schedule>? Availability { get; set; }
    }
}
