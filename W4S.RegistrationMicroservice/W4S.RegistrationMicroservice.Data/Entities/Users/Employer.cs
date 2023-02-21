using System.ComponentModel.DataAnnotations.Schema;

namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    [Table("Employers")]
    public class Employer : User
    {
        public required string PositionName { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
