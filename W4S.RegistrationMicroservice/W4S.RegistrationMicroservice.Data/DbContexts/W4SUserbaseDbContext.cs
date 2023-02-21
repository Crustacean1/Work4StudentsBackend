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

        public DbSet<Entity> Entities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Domain> UniversitiesDomains { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<StudentSchedule>  StudentSchedules { get; set; }


        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await Database.MigrateAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().Property(e => e.Id).ValueGeneratedNever();

            // User
            modelBuilder.Entity<User>().Property(e => e.EmailAddress).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.SecondName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(e => e.PhoneNumber).HasMaxLength(15);

            // Student
            modelBuilder.Entity<Student>().Property(e => e.UniversityId).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.RoleId).IsRequired();

            // Employer
            modelBuilder.Entity<Employer>().Property(e => e.CompanyId).IsRequired();
            modelBuilder.Entity<Employer>().Property(e => e.RoleId).IsRequired();

            // Administrator
            modelBuilder.Entity<Administrator>().Property(e => e.RoleId).IsRequired();

            // Domain
            modelBuilder.Entity<Domain>().Property(e => e.EmailDomain);

            // Company
            modelBuilder.Entity<Company>().Property(e => e.NIP).HasMaxLength(10);

            // Roles
            modelBuilder.Entity<Role>().Property(e => e.Description).IsRequired();
                        
            // Profiles
            modelBuilder.Entity<Profile>().Property(x => x.Description).HasMaxLength(500);
            modelBuilder.Entity<Profile>().Property(x => x.Country).IsRequired();
            modelBuilder.Entity<Profile>().Property(x => x.Region).IsRequired();
            modelBuilder.Entity<Profile>().Property(x => x.City).IsRequired();
            modelBuilder.Entity<Profile>().Property(x => x.Street).IsRequired();
            modelBuilder.Entity<Profile>().Property(x => x.Building).IsRequired();
            modelBuilder.Entity<Profile>().Property(x => x.EmailAddress).IsRequired();

            //Seeding values...
            modelBuilder.Entity<Role>().HasData(new List<Role>() { _seeder.StudentRole, _seeder.EmployerRole, _seeder.AdminRole });
            modelBuilder.Entity<Domain>().HasData(_seeder.EmailDomain);
            modelBuilder.Entity<Domain>().HasData(new List<Domain>() { _seeder.Domain1, _seeder.Domain2, _seeder.Domain3, _seeder.Domain4 });
            modelBuilder.Entity<University>().HasData(_seeder.University);
            modelBuilder.Entity<University>().HasData(new List<University>() { _seeder.University1, _seeder.University2, _seeder.University3, _seeder.University4 });
            modelBuilder.Entity<Company>().HasData(_seeder.Company);
            modelBuilder.Entity<Company>().HasData(new List<Company>() { _seeder.Company1, _seeder.Company2, _seeder.Company3, 
                _seeder.Company4, _seeder.Company5, _seeder.Company6, _seeder.Company7, _seeder.Company8, _seeder.Company9 });

            //modelBuilder.Entity<Domain>().HasData(_seeder.UniversityDomains);
            //modelBuilder.Entity<University>().HasData(_seeder.Universities);
            //modelBuilder.Entity<Company>().HasData(_seeder.Companies);

            modelBuilder.Entity<Administrator>().HasData(_seeder.Admin);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
