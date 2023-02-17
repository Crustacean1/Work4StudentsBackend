using W4S.PostingService.Domain.ValueType;
using NpgsqlTypes;
using W4S.PostingService.Models.Entities;

namespace W4S.PostingService.Domain.Entities
{
    public class JobOffer : Entity
    {
        public Guid RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }

        public OfferStatus Status { get; set; }

        public WorkMode Mode { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } = "";

        public string Role { get; set; }

        public Address Address { get; set; }

        public PayRange PayRange { get; set; }

        public DateTime CreationDate { get; set; }

        public string Categories { get; set; } = "";

        public ICollection<Schedule> WorkingHours { get; set; } = new List<Schedule>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public ICollection<OfferReview> Reviews { get; set; } = new List<OfferReview>();

        public NpgsqlTsVector SearchVector { get; set; }
    }
}
