namespace W4S.RegistrationMicroservice.Data.Entities
{
    public class Company : Entity
    {
        public required string Name { get; set; }
        public required string NIP { get; set; }
    }
}
