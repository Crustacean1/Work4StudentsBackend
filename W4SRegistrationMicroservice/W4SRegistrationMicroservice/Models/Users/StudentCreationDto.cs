namespace W4SRegistrationMicroservice.API.Models.Users
{
    public class StudentCreationDto : IUserCreationDto
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
