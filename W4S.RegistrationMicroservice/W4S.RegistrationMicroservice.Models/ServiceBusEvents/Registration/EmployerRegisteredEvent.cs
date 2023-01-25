namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class EmployerRegisteredEvent : BaseRegistrationEvent
    {
        public string NIP { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
    }
}
