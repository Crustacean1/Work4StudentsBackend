using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Persistence
{
    public class Seeder
    {
        public Company FakeCompany { get; set; }
        public Recruiter FakeRecruiter { get; set; }
        public Applicant FakeApplicant { get; set; }
        public Application FakeApplication { get; set; }
        public JobOffer FakeJobOffer { get; set; }
        public Address FakeAddress { get; set; }
        public PayRange FakePayRange { get; set; }

        public Seeder()
        {
            FakeAddress = new Address
            {
                Country = "Ethiopia",
                Region = "asdsh",
                City = "sdfasdf",
                Street = "adsfasdf",
                Building = "Mud Hut"
            };

            FakePayRange = new PayRange
            {
                Min = 0,
                Max = 100
            };

            FakeCompany = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Company",
                Description = "It is what it is",
            };

            FakeRecruiter = new Recruiter
            {
                FirstName = "John",
                Surname = "Smith",
                PhoneNumber = "123456789",
                Email = "noreply@company.et",

                Id = Guid.NewGuid(),
                CompanyId = FakeCompany.Id,
            };

            FakeJobOffer =
                new()
                {
                    Id = Guid.NewGuid(),
                    RecruiterId = FakeRecruiter.Id,
                    Title = "Opening for position A",
                    Description = "Fancy job",
                    Status = JobOffer.OfferStatus.Active,
                    Role = "Position A",
                    Openings = 21,
                    WorkingHours = new List<Schedule>(),
                    Applications = new List<Application>(),
                };

            FakeApplicant = new Applicant()
            {
                FirstName = "John",
                Surname = "Smith",
                PhoneNumber = "123456789",
                Email = "noreply@company.et",

                Id = Guid.NewGuid(),
                Availability = new List<Schedule>(),
                Applications = new List<Application>(),
            };

            FakeApplication = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = FakeJobOffer.Id,
                ApplicantId = FakeApplicant.Id,
                WorkTimeOverlap = 0.0M,
                Proximity = 1.0M,
                LastChange = DateTime.Now.ToUniversalTime(),
                Status = Application.ApplicationStatus.Submitted,
                Message = "I want to work pls"
            };
        }
    }
}
