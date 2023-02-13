using System.ComponentModel.DataAnnotations.Schema;

namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    [Table("Students")]
    public class Student : User
    {
        public Guid UniversityId { get; set; }

        public virtual University University { get; set; }
    }
}
