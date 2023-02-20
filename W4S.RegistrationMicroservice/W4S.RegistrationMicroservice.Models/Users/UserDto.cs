namespace W4S.RegistrationMicroservice.Models.Users
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}
