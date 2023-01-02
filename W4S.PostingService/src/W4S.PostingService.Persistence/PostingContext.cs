using Microsoft.EntityFrameworkCore;
using PostingService.Persistence.Entities;

namespace PostingService.Persistence
{
    public class PostingContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=job_offers;Host=localhost;Port=5432;User=postgres;Password=postgres";

        public DbSet<ApplicantEntity> Applicants;

        public DbSet<ApplicationEntity> Applications;

        public DbSet<CompanyEntity> Companies;

        public DbSet<RecruiterEntity> Recruiters;

        public DbSet<JobOfferEntity> JobOffers;

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }
    }
}
