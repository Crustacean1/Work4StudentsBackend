namespace W4S.PostingService.Domain.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
