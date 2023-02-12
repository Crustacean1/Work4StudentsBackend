namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles
{
    public class StudentRatingChangedEvent // get rating from another service
    {
        public Guid StudentId { get; set; }
        public decimal Rating { get; set; }
    }
}
