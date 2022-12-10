using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using W4SRegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.Data.Entities.Universities;
using W4SRegistrationMicroservice.Data.Entities.Users;
using W4SRegistrationMicroservice.Data.Entities.Users.User_Settings;

namespace W4SRegistrationMicroservice.Data.DbContexts
{
    public class W4SUserbaseDbContext : DbContext
    {
        private readonly string _connectionString;
        private ILogger<W4SUserbaseDbContext> _logger;
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Domain> UniversitiesDomains { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public W4SUserbaseDbContext(
            IConfiguration configuration,
            ILogger<W4SUserbaseDbContext> logger)
        {
            _connectionString = configuration.GetConnectionString("W4SRegistrationUserbase");
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(e => e.UniversityId).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.RoleId).IsRequired();

            // Employer
            modelBuilder.Entity<Employer>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Employer>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Employer>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Employer>().Property(e => e.CompanyId).IsRequired();
            modelBuilder.Entity<Employer>().Property(e => e.RoleId).IsRequired();

            // Administrator
            modelBuilder.Entity<Administrator>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<Administrator>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Administrator>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Administrator>().Property(e => e.RoleId).IsRequired();

            // University
            modelBuilder.Entity<University>().Property(e => e.Name).HasMaxLength(100);

            // Domain
            modelBuilder.Entity<Domain>().Property(e => e.EmailDomain).HasMaxLength(20);

            // Company
            modelBuilder.Entity<Company>().Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(e => e.NIP).HasMaxLength(10);

            // Roles
            modelBuilder.Entity<Roles>().Property(e => e.Role).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
