using Microsoft.EntityFrameworkCore;
using W4SRegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.DbContexts
{
    public class W4SUserbaseDbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
