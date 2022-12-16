using Microsoft.EntityFrameworkCore;
using PostingService.Persistence.Entities;

namespace PostingService.Persistence
{
    public class PostingContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=job_offers;Host=localhost;Port=5432;User=postgres;Password=postgres";

        public DbSet<Applicant> Applicants;

        public DbSet<Application> Applications;

        public DbSet<Company> Companies;

        public DbSet<Recruiter> Recruiters;

        public DbSet<JobOffer> JobOffers;

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
