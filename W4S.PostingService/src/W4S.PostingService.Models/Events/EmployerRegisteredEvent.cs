using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Models.Events
{
    public class EmployerRegisteredEvent : UserRegistrationEvent
    {
        public string? NIP { get; set; }
        public string? CompanyName { get; set; }
        public string? PositionName { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
