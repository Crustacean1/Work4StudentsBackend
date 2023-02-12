using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.CommonServices.Services;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;

namespace W4S.RegistrationMicroservice.Data.Seeders
{
    public class UserbaseSeeder
    {
        private readonly PasswordHasher _passwordHasher = new();

        public Role AdminRole { get; set; }
        public Role StudentRole { get; set; }
        public Role EmployerRole { get; set; }

        public University University { get; set; }
        public Company Company { get; set; }

        public Student Student { get; set; }
        public Employer Employer { get; set; }
        public Administrator Admin { get; set; }

        public Domain EmailDomain { get; set; }

        public Rating Rating { get; set; }

        public ProfilePhoto ProfilePhoto { get; set; }
        public EmployerProfile EmployerProfile { get; set;}
        public StudentProfile StudentProfile { get; set;}


        public UserbaseSeeder()
        {
            Seed();
        }

        public void Seed()
        {
            EmailDomain = new Domain
            {
                Id = Guid.NewGuid(),
                EmailDomain = "@polsl.pl"
            };

            AdminRole = new Role()
            {
                Id = Guid.NewGuid(),
                Description = "Administrator"
            };

            StudentRole = new Role()
            {
                Id = Guid.NewGuid(),
                Description = "Student"
            };

            EmployerRole = new Role()
            {
                Id = Guid.NewGuid(),
                Description = "Employer"
            };

            Company = new Company()
            {
                Id = Guid.NewGuid(),
                NIP = "5283121250",
                Name = "Empty firm in Poland"
            };

            University = new University()
            {
                Id = Guid.NewGuid(),
                Name = "Politechnika Śląska",
                EmailDomainId = EmailDomain.Id
            };

            Student = new Student()
            {
                Id = Guid.NewGuid(),
                EmailAddress = "student.debil@polsl.pl",
                PasswordHash = _passwordHasher.HashText("admin"),
                Name = "John",
                SecondName = "Karol",
                Surname = "Pavulon",
                PhoneNumber = "+2137",
                RoleId = StudentRole.Id,
                UniversityId = University.Id
            };

            Employer = new Employer()
            {
                Id = Guid.NewGuid(),
                EmailAddress = "someEmployer@gmail.com",
                Name = "Adam",
                SecondName = "Szef",
                Surname = "Małysz",
                PasswordHash = _passwordHasher.HashText("admin"),
                PhoneNumber = "2137",
                RoleId = EmployerRole.Id,
                CompanyId = Company.Id,
                PositionName = "Majster HR"
            };

            Admin = new Administrator()
            {
                Id = Guid.NewGuid(),
                EmailAddress = "someAdmin@gmail.com",
                Name = "Admin",
                SecondName = "Adminsky",
                Surname = "Administator",
                PasswordHash = _passwordHasher.HashText("admin1234"),
                PhoneNumber = "2137",
                RoleId = AdminRole.Id
            };

            ProfilePhoto = new ProfilePhoto()
            {
                Id = Guid.NewGuid(),
                PhotoFile = new byte[] { 0x00, 0x00, 0x00, 0x00 }
            };

            EmployerProfile = new EmployerProfile()
            {
                Id = Guid.NewGuid(),
                EmployerId = Employer.Id,
                Description = "My company is the best.",
                PhotoId = ProfilePhoto.Id,
            };


            StudentProfile = new StudentProfile()
            {
                Id = Guid.NewGuid(),
                StudentId = Student.Id,
                Description = "My university is the best.",
                PhotoId = ProfilePhoto.Id
            };

            Rating = new Rating()
            {
                Id = Guid.NewGuid(),
                StudentId = Student.Id,
                RatingValue = 5.0m
            };

        }
    }
}
