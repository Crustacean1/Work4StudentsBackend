namespace W4S.RegistrationMicroservice.Data.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string NIP { get; set; }
    }
}
