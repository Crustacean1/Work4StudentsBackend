using Microsoft.EntityFrameworkCore;
using W4S.PostingService.Domain.Models;

namespace W4S.PostingService.Persistence
{
    public class PostingContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=offers;Host=localhost;Port=5432;Username=root;Password=root";

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Owned<Address>();
            builder.Owned<PayRange>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
