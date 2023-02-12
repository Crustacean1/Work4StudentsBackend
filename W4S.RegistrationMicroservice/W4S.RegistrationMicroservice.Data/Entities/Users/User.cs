namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    public class User : Entity
    {
        public required string EmailAddress { get; set; }
        public required string PasswordHash { get; set; }
        public required string Name { get; set; }
        public string? SecondName { get; set; }
        public required string Surname { get; set; }
        public string? PhoneNumber { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
