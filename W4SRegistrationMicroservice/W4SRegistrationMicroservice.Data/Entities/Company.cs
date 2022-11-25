using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.Entities
{
    public class Company
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
