using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Data.Entities.Users
{
    public class Rating
    {
        public Guid Id { get; set; }
        public decimal RatingValue { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
