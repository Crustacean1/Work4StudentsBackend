namespace W4S.PostingService.Domain.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public string Description { get; set; }
    }
}
