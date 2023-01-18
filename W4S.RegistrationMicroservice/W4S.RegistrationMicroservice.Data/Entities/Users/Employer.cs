using System.ComponentModel.DataAnnotations.Schema;

namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    [Table("Employers")]
    public class Employer : User
    {
        public required string PositionName { get; init; }
        public Guid CompanyId { get; init; }
        public virtual Company Company { get; init; }
    }
}
