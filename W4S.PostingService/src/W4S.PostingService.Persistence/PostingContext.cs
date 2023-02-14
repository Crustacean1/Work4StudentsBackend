using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Persistence
{
    public class PostingContext : DbContext
    {
        private readonly string DEFAULT_CONNECTION_STRING = "Database=offers;Host=localhost;Port=5432;Username=root;Password=root";
        private readonly Seeder seeder = new();

        public DbSet<Student> Applicants { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<OfferReview> OfferReviews { get; set; }

        public DbSet<ApplicationReview> ApplicationReviews { get; set; }

        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Review>();

            builder.Entity<OfferReview>()
                .ToTable("OfferReviews");

            builder.Entity<ApplicationReview>()
                .ToTable("ApplicationReviews");

            builder.Entity<Company>(b =>
            {
                b.HasData(seeder.FakeCompany);
            });

            builder.Entity<Recruiter>(b =>
            {
                b.HasData(seeder.FakeRecruiter);
                b.HasMany(r => r.Offers);
                b.HasOne(r => r.Company);
            });

            builder.Entity<JobOffer>(b =>
            {
                b.OwnsOne(jo => jo.Address);
                b.OwnsOne(jo => jo.PayRange);
                b.OwnsMany(jo => jo.WorkingHours);
                b.HasMany<OfferReview>().WithOne().HasForeignKey(r => r.SubjectId);
            });

            builder.Entity<Student>(b =>
            {
                b.OwnsOne(a => a.Address).HasData(new
                {
                    Country = "Polandia",
                    Region = "Silesia",
                    City = "Gliwice",
                    Street = "Street",
                    Building = "Boilding",
                    StudentId = seeder.FakeApplicant.Id
                });
                b.OwnsMany(a => a.Availability);
                b.HasData(seeder.FakeApplicant);
            });

            builder.Entity<Application>(b =>
            {
                b.HasOne(a => a.Student);
                b.HasOne(a => a.Offer);
                b.HasMany<ApplicationReview>().WithOne().HasForeignKey(r => r.SubjectId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.LogTo(Console.WriteLine)
            builder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? DEFAULT_CONNECTION_STRING);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveConversion(typeof(UtcValueConverter));
        }

        private class UtcValueConverter : ValueConverter<DateTime, DateTime>
        {
            public UtcValueConverter()
                : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            {
            }
        }
    }
}
