using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Models
{
    public class JobOffer : Entity
    {
        private List<Application> applications = new();

        public enum OfferStatus
        {

            Active,
            Finished,
            Cancelled
        }

        public Guid Id { get; set; }

        public Recruiter Recruiter { get; set; }

        public OfferStatus Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }

        public Address Address { get; set; }

        public uint Openings { get; set; }

        public PayRange PayRange { get; set; }

        public Schedule WorkingHours { get; set; }

        public IEnumerable<Application> Applications => applications;

        public Guid Apply(Applicant applicant, Notification notification)
        {
            if (Status == OfferStatus.Active)
            {
                if (Applications.SingleOrDefault(a => a.Applicant.Id == applicant.Id) is not null)
                {
                    notification.AddError("Cannot apply twice for the same position");
                    return Guid.Empty;
                }

                var application = new Application
                {
                    Id = Guid.NewGuid(),
                    Applicant = applicant,
                    Offer = this,
                    WorkTimeOverlap = 1.0M,
                    Proximity = 1.0M,
                    ApplicationDate = DateTime.Now,
                    Status = Application.ApplicationStatus.Pending
                };

                applications.Add(application);
                return application.Id;
            }
            else
            {
                notification.AddError("Cannot apply for inactive offer");
                return Guid.Empty;
            }
        }

        public void Cancel(Notification notification)
        {
            if (Status == OfferStatus.Active)
            {
                Status = OfferStatus.Cancelled;
            }
            else
            {
                notification.AddError("Cannot cancel inactive job offer");
            }
        }

        public void Accept(IEnumerable<Guid> applications, Notification notification)
        {
            var remainingOpenings = Openings - this.applications.Count;

            var invalidApplications = applications.Where(id =>
            {
                var application = Applications.SingleOrDefault(a => a.Id == id);
                return application is null || application.Status != Application.ApplicationStatus.Pending;
            });

            if (invalidApplications.Any())
            {
                var invalidGuids = invalidApplications.Aggregate("", (a, b) => $"{a}, {b}");
                notification.AddError($"Incorrect or withdrawn applications specified: {invalidGuids}");
            }

            if (remainingOpenings < applications.Count())
            {
                notification.AddError($"Invalid operation: Tried to accept {applications.Count()} applications, while only {remainingOpenings} positions are available");
            }

            if (!notification.HasErrors)
            {
                foreach (var application in this.applications)
                {
                    if (applications.SingleOrDefault(id => application.Id == id) != default)
                    {
                        application.Accept(notification);
                    }
                    else
                    {
                        application.Reject(notification);
                    }
                }
            }
        }
    }
}
