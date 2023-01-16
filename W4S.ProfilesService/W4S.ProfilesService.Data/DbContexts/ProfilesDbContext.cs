using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4S.ProfilesService.Data.Entities.Profiles;
using W4S.ProfilesService.Data.Entities.Users;
using W4S.ProfilesService.Data.Entities.Workplaces;

namespace W4S.ProfilesService.Data.DbContexts
{
    public class ProfilesDbContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=profiles;Host=localhost;Port=5432;Username=root;Password=root"; // maybe not this port tho

        public DbSet<University> Universities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.SecondName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.LastName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasMaxLength(12); // +xx xxx-xxx-xxx

            modelBuilder.Entity<Employer>().Property(x => x.PositionName).HasMaxLength(30);

            modelBuilder.Entity<Profile>().Property(x => x.Image).HasMaxLength(5242880); // 5MB in bytes
            modelBuilder.Entity<Profile>().Property(x => x.Description).HasMaxLength(500);

            modelBuilder.Entity<StudentProfile>().Property(x => x.ResumeFile).HasMaxLength(5242880); // 5MB in bytes

            modelBuilder.Entity<University>().Property(x => x.Name).HasMaxLength(100);

            modelBuilder.Entity<Company>().Property(x => x.Name).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
