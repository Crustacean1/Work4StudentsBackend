using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.Entities.Universities
{
    public class University
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long EmailDomainId { get; set; }
        public virtual Domain EmailDomain { get; set; }
    }
}
