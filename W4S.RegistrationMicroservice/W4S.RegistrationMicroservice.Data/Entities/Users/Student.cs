using System.ComponentModel.DataAnnotations.Schema;

namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    [Table("Students")]
    public class Student : User
    {
        public Guid UniversityId { get; init; }

        public virtual University University { get; init; }
    }
}
