namespace W4SRegistrationMicroservice.Data.Entities.Users
{
    public class Employer : User
    {
        public required string PositionName { get; set; }

        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
