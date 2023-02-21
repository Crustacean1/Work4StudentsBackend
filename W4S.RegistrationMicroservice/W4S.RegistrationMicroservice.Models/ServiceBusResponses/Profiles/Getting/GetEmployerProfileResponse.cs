namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Getting
{
    public class GetEmployerProfileResponse : BaseResponse
    {
        public Guid ProfileId { get; set; }
        public Guid EmployerId { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? Description { get; set; }
        public decimal Rating { get; set; }
        public string? Photo { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
    }
}
