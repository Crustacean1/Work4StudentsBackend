namespace W4SRegistrationMicroservice.Data.Entities.Users
{
    public class Student : User
    {
        public long UniversityId { get; set; }

        public virtual University University { get; set; }
    }
}
