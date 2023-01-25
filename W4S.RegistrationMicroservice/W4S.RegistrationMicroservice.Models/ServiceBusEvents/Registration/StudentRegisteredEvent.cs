namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class StudentRegisteredEvent : BaseRegistrationEvent
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string UniversityDomain { get; set; }
    }
}
