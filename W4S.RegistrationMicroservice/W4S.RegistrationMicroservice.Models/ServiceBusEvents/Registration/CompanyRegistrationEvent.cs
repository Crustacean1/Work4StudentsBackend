namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class CompanyRegistrationEvent : BaseRegistrationEvent
    {
        public string CompanyName { get; set; }
    }
}
