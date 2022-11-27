using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using W4SRegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.Data.Entities.Universities;
using W4SRegistrationMicroservice.Data.Entities.Users;

namespace W4SRegistrationMicroservice.Data.DbContexts
{
    public class W4SUserbaseDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Domain> UniversitiesDomains { get; set; }

        public W4SUserbaseDbContext()
        {

        }

        public W4SUserbaseDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(e => e.UniversityId).IsRequired();

            // Employer
            modelBuilder.Entity<Employer>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Employer>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Employer>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Employer>().Property(e => e.CompanyId).IsRequired();

            // Administrator
            modelBuilder.Entity<Administrator>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Administrator>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Administrator>().Property(e => e.Surname).HasMaxLength(50);

            // University
            modelBuilder.Entity<University>().Property(e => e.Name).HasMaxLength(100);

            // Domain
            modelBuilder.Entity<Domain>().Property(e => e.EmailDomain).HasMaxLength(20);

            // Company
            modelBuilder.Entity<Company>().Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(e => e.NIP).HasMaxLength(9);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=W4SRegistrationUserbase;Trusted_Connection=True;");
        }
    }
}
