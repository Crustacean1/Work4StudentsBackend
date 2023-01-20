using Microsoft.EntityFrameworkCore;
using W4S.RegistrationMicroservice.Data.Seeders;
using W4S.RegistrationMicroservice.Data.Entities;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;

namespace W4S.RegistrationMicroservice.Data.DbContexts
{
    public class UserbaseDbContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=users;Host=localhost;Port=5432;Username=root;Password=root";

        private readonly UserbaseSeeder _seeder = new();

        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Domain> UniversitiesDomains { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }


        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await Database.MigrateAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.SecondName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.PhoneNumber).HasMaxLength(10);

            // Student
            modelBuilder.Entity<Student>().Property(e => e.UniversityId).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.RoleId).IsRequired();

            // Employer
            modelBuilder.Entity<Employer>().Property(e => e.CompanyId).IsRequired();
            modelBuilder.Entity<Employer>().Property(e => e.RoleId).IsRequired();

            // Administrator
            modelBuilder.Entity<Administrator>().Property(e => e.RoleId).IsRequired();

            // University
            modelBuilder.Entity<University>().Property(e => e.Name).HasMaxLength(100);

            // Domain
            modelBuilder.Entity<Domain>().Property(e => e.EmailDomain).HasMaxLength(20);

            // Company
            modelBuilder.Entity<Company>().Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(e => e.NIP).HasMaxLength(10);

            // Roles
            modelBuilder.Entity<Role>().Property(e => e.Description).IsRequired();

            modelBuilder.Entity<Rating>().Property(e => e.Id).IsRequired();
            modelBuilder.Entity<Rating>().Property(e => e.StudentId).IsRequired();
            
            // Profiles
            modelBuilder.Entity<Profile>().Property(x => x.Image).HasMaxLength(5242880); // 5MB in bytes
            modelBuilder.Entity<Profile>().Property(x => x.Description).HasMaxLength(500);

            // StudenProfiles
            modelBuilder.Entity<StudentProfile>().Property(x => x.ResumeFile).HasMaxLength(5242880); // 5MB in bytes

            //Seeding values...

            modelBuilder.Entity<Role>().HasData(new List<Role>() { _seeder.StudentRole, _seeder.EmployerRole, _seeder.AdminRole });
            modelBuilder.Entity<Domain>().HasData(_seeder.EmailDomain);
            modelBuilder.Entity<University>().HasData(_seeder.University);
            modelBuilder.Entity<Company>().HasData(_seeder.Company);

            modelBuilder.Entity<Student>().HasData(_seeder.Student);
            modelBuilder.Entity<Employer>().HasData(_seeder.Employer);
            modelBuilder.Entity<Administrator>().HasData(_seeder.Admin);

            modelBuilder.Entity<StudentProfile>().HasData(_seeder.StudentProfile);
            modelBuilder.Entity<EmployerProfile>().HasData(_seeder.EmployerProfile);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
