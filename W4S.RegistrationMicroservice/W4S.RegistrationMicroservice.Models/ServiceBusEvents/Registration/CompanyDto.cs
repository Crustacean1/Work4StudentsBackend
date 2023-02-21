namespace W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
