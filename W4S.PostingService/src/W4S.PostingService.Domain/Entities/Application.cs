using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Entities
{
    public class Application : Entity
    {
        public enum ApplicationStatus
        {
            Created,
            Submitted,
            Withdrawn,
            Accepted,
            Rejected
        }

        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        public JobOffer Offer { get; set; }

        public Guid ApplicantId { get; set; }

        public Applicant Applicant { get; set; }


        public decimal WorkTimeOverlap { get; set; }

        public decimal Proximity { get; set; }

        public DateTime LastChange { get; set; }

        public ApplicationStatus Status { get; set; }

        public string Message { get; set; }

        public void Submit(Notification notification)
        {
            if (Status != ApplicationStatus.Created)
            {
                notification.AddError("Submit application: only newly created application can be submitted");
            }
            if (Applicant is null)
            {
                notification.AddError("Submit application: applicant is not defined");
            }
            if (Offer is null)
            {
                notification.AddError("Submit application: offer is not defined");
            }

            if (!notification.HasErrors)
            {
                Status = ApplicationStatus.Submitted;
                LastChange = DateTime.Now;
                WorkTimeOverlap = 0.2137M;
                Proximity = 1234;
                Applicant!.Applications.Add(this);
                Offer!.Applications.Add(this);
            }
        }

        public void Accept(Notification notification)
        {
            if (Status != ApplicationStatus.Submitted)
            {
                notification.AddError("Could not accept application, only pending application can be accepted");
                return;
            }

            Status = ApplicationStatus.Accepted;
            LastChange = DateTime.Now;
        }

        public void Reject(Notification notification)
        {
            if (Status != ApplicationStatus.Submitted)
            {
                notification.AddError("Could not reject application, only pending application can be rejected");
                return;
            }

            Status = ApplicationStatus.Rejected;
            LastChange = DateTime.Now;
        }

        public void Withdraw(Notification notification)
        {
            if (Status != ApplicationStatus.Submitted)
            {
                notification.AddError("Could not withdraw application, only pending application can be withdrawn");
                return;
            }

            Status = ApplicationStatus.Withdrawn;
            LastChange = DateTime.Now;
        }
    }
}
