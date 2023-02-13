namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class StudentRegisteredEvent : BaseRegistrationEvent
    {
        public string UniversityDomain { get; set; }
    }
}
