namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles
{
    public class UserRatingChangedEvent // get rating from another service
    {
        public Guid UserId { get; set; }    // will check if student or employer
        public decimal Rating { get; set; }
    }
}
