using Microsoft.EntityFrameworkCore;
using PostingService.Persistence.Entities;

namespace PostingService.Persistence
{
    public class PostingContext : DbContext
    {
        public DbSet<Applicant> Applicants;

        public DbSet<Application> Applications;

        public DbSet<Poster> Posters;

        public DbSet<Posting> Postings;
    }
}
