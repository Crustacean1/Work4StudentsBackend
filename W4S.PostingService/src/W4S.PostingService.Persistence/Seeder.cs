using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Persistence
{
    public class Seeder
    {
        public Company FakeCompany { get; set; }
        public Recruiter FakeRecruiter { get; set; }
        public Student FakeApplicant { get; set; }
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
                Name = "Comarch",
                NIP = "7821160955",
            };

            FakeRecruiter = new Recruiter
            {
                FirstName = "John",
                Surname = "Smith",
                PhoneNumber = "123456789",
                EmailAddress = "noreply@company.et",

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
                    Status = OfferStatus.Active,
                    Role = "Position A",
                    WorkingHours = new List<Schedule>(),
                    Applications = new List<Application>(),
                };

            FakeApplicant = new Student()
            {
                FirstName = "John",
                Surname = "Smith",
                PhoneNumber = "123456789",
                EmailAddress = "noreply@company.et",

                Id = Guid.NewGuid(),
                Availability = new List<Schedule>(),
                Applications = new List<Application>(),
            };

            FakeApplication = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = FakeJobOffer.Id,
                StudentId = FakeApplicant.Id,
                WorkTimeOverlap = 0.0M,
                Proximity = 1.0M,
                LastChanged = DateTime.Now.ToUniversalTime(),
                Status = ApplicationStatus.Submitted,
                Message = "I want to work pls"
            };
        }
    }
}
