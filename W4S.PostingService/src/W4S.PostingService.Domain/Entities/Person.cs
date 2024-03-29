using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Entities;

namespace W4S.PostingService.Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public decimal Rating { get; set; } = 0.0M;

        public string? SecondName { get; set; } = "";

        public string Surname { get; set; }

        public string? PhoneNumber { get; set; } = "";

        public string EmailAddress { get; set; }

        public Address Address { get; set; }
    }
}
