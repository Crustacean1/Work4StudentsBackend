using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Models;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Persistence
{
    public class Seeder
    {
        public Company FakeCompany { get; set; }
        public Recruiter FakeRecruiter { get; set; }
        public Student FakeStudent { get; set; }
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

            FakeStudent = new Student()
            {
                FirstName = "John",
                Surname = "Smith",
                PhoneNumber = "123456789",
                EmailAddress = "noreply@company.et",

                Id = Guid.NewGuid(),
                Availability = new List<Schedule>(),
                Applications = new List<Application>(),
            };

            var fakeJobOfferId = Guid.NewGuid();
            FakeJobOffer =
                new()
                {
                    Id = fakeJobOfferId,
                    RecruiterId = FakeRecruiter.Id,
                    Title = "Opening for position A",
                    Description = "Fancy job",
                    Status = OfferStatus.Active,
                    Role = "Position A",
                    WorkingHours = new List<Schedule>(),
                    Applications = new List<Application>(),
                    Reviews = new List<Review>{
                        new Review
                        {
                            Title = "Recruitment process",
                            Message = "Went great",
                            SubjectId = fakeJobOfferId,
                            AuthorId = FakeStudent.Id,
                            Rating = 5.0m
                        }
                    }
                };

            FakeApplication = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = FakeJobOffer.Id,
                StudentId = FakeStudent.Id,
                WorkTimeOverlap = 0.0M,
                Distance = 0.0,
                LastChanged = DateTime.Now.ToUniversalTime(),
                Status = ApplicationStatus.Submitted,
                Message = "I want to work pls"
            };
        }
    }
}
