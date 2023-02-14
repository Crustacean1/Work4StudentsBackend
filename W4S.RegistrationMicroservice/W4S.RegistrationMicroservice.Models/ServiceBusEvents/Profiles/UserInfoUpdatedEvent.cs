using W4S.RegistrationMicroservice.Models.Profiles;

namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles
{
    public class UserInfoUpdatedEvent // send to other services
    {
        public Guid UserId { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }

        public List<ScheduleProfile>? Avaiability { get; set; }
    }
}
