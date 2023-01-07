using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Models
{
    public class Application : Entity
    {
        public enum ApplicationStatus
        {
            Pending,
            Withdrawn,
            Accepted,
            Rejected
        }

        public Guid Id { get; set; }

        public JobOffer Offer { get; set; }

        public Applicant Applicant { get; set; }

        public decimal WorkTimeOverlap { get; set; }

        public decimal Proximity { get; set; }

        public DateTime ApplicationDate { get; set; }

        public ApplicationStatus Status { get; set; }

        public void Submit(Applicant applicant, JobOffer offer)
        {
            Offer = offer;
            Applicant = applicant;
            Status = ApplicationStatus.Pending;
            WorkTimeOverlap = 1.0M;
            Proximity = 1.0M;
            ApplicationDate = DateTime.Now;
        }

        public void Withdraw(Notification notification)
        {
            if (Status != ApplicationStatus.Pending)
            {
                notification.AddError("Only pending application can be withdrawn");
            }
            else
            {
                Status = ApplicationStatus.Withdrawn;
            }
        }

        public void Accept(Notification notification)
        {
            if (Status == ApplicationStatus.Pending)
            {
                Status = ApplicationStatus.Accepted;
            }
            else
            {
                notification.AddError($"Cannot accept application that isn't in 'pending' state: {Id}");
            }
        }

        public void Reject(Notification notification)
        {
            if (Status == ApplicationStatus.Pending)
            {
                Status = ApplicationStatus.Rejected;
            }
            else
            {
                notification.AddError($"Cannot reject application that isn't in 'pending' state: {Id}");
            }
        }
    }
}
