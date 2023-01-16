namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    public class User
    {
        public Guid Id { get; init; }
        public required string EmailAddress { get; init; }
        public required string PasswordHash { get; init; }
        public required string Name { get; init; }
        public string SecondName { get; init; }
        public required string Surname { get; init; }
        public string PhoneNumber { get; init; }

        public Guid RoleId { get; init; }
        public virtual Role Role { get; init; }
    }
}
