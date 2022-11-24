using W4SRegistrationMicroservice.Entities.Users;

namespace W4SRegistrationMicroservice.Entities
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Employer> Employers { get; set; }
    }
}
