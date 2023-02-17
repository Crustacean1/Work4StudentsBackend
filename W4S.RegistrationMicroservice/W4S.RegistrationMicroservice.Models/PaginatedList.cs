namespace W4S.RegistrationMicroservice.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
