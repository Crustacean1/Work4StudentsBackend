using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.Entities
{
    public class University
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }

        public List<Student> Students { get; set; } 
    }
}
