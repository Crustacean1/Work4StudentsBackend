namespace W4S.RegistrationMicroservice.Data.Entities
{
    public class University : Entity
    {
        public required string Name { get; set; }
        public Guid EmailDomainId { get; set; }
        public virtual Domain EmailDomain { get; set; }
    }
}
