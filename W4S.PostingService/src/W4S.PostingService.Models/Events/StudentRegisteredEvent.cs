namespace W4S.PostingService.Models.Events
{
    public class StudentRegisteredEvent : UserRegistrationEvent
    {
        public string? UniversityDomain { get; set; }
    }
}
