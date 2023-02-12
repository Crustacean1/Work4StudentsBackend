namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class EmployerRegisteredEvent : BaseRegistrationEvent
    {
        public CompanyDto Company { get; set; }
    }
}
