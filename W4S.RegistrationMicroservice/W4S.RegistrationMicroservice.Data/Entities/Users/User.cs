using W4SRegistrationMicroservice.Data.Entities.Users.User_Settings;

namespace W4SRegistrationMicroservice.Data.Entities.Users {
    public class User
    {
        public long Id { get; set; }
        public required string EmailAddress { get; set; }
        public required string PasswordHash { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }

        public long RoleId { get; set; }
        public virtual Roles Role { get; set; }
    }
}
