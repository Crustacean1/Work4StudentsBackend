namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class EmployerRegisteredEvent : BaseRegistrationEvent
    {
        public string NIP { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
