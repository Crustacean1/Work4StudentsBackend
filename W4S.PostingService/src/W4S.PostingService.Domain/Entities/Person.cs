using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public decimal Rating { get; set; } = 0;

        public string? SecondName { get; set; } = "";

        public string Surname { get; set; }

        public string? PhoneNumber { get; set; } = "";

        public string EmailAddress { get; set; }

        public Address Address { get; set; }
    }
}
