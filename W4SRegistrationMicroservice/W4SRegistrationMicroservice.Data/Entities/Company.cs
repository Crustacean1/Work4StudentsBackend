using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.Entities
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Employer> Employers { get; set; }
    }
}
