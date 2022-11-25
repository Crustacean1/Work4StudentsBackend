using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.Entities
{
    public class University
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Domain { get; set; }
    }
}
