namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class BaseRegistrationEvent : BaseEvent
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
    }
}
