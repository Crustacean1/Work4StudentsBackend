namespace W4S.RegistrationMicroservice.Models
{
    public class MetaData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount => (TotalCount + PageSize - 1) / PageSize;
    }
}
