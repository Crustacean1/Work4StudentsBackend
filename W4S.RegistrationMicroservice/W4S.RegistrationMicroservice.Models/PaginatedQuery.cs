
using System.ComponentModel.DataAnnotations;

namespace W4S.RegistrationMicroservice.Models
{
    public class PaginatedQuery
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        [Range(1, 100)]
        public int PageSize { get; set; }

        public string Query { get; set; } = "";
    }
}
