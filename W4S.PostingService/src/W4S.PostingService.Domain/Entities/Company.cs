using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public string Description { get; set; }
    }
}
