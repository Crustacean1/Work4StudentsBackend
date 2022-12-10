using System.ComponentModel.DataAnnotations.Schema;
using W4SRegistrationMicroservice.Data.Entities.Universities;

namespace W4SRegistrationMicroservice.Data.Entities.Users
{
    [Table("Students")]
    public class Student : User
    {
        public long UniversityId { get; set; }

        public virtual University University { get; set; }
    }
}
