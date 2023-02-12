using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Company : Entity
    {
        public string NIP { get; set; }

        public string Name { get; set; }
    }
}
