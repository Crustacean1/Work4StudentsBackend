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
                Country = "Poland",
                Region = "Silesia",
                City = "Gliwice",
                Street = "Akademicka",
                Building = "2a",
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
                Country = "Poland",
                Region = "Silesia",
                City = "Gliwice",
                Street = "Akademicka",
                Building = "2a",
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
                Country = "Poland",
                Region = "Silesia",
                City = "Gliwice",
                Street = "Akademicka",
                Building = "2a",
                RoleId = AdminRole.Id
            };

            EmployerProfile = new EmployerProfile()
            {
                Id = Guid.NewGuid(),
                EmployerId = Employer.Id,
                //Employer = Employer,
                EmailAddress = Employer.EmailAddress,
                Description = "My company is the best.",
                ShortDescription = "My company...",
                CompanyName = Company.Name,
                Education = "Bachelor in Milfology",
                Experience = "5 years as Milfhunter",
                Country = Employer.Country,
                Region = Employer.Region,
                City = Employer.City,
                Street = Employer.Street,
                Building = Employer.Building,
                PhoneNumber = Employer.PhoneNumber,
                PositionName = Employer.PositionName,
                Rating = 0.0m,
                PhotoFile = null
            };


            StudentProfile = new StudentProfile()
            {
                Id = Guid.NewGuid(),
                StudentId = Student.Id,
                //Student = Student,
                Description = "My university is the best.",
                EmailAddress = Employer.EmailAddress,
                ShortDescription = "My university...",
                Education = "Silesian University of Science, Informatics",
                Experience = "20 years in Unity",
                Country = Student.Country,
                Region = Student.Region,
                City = Student.City,
                Street = Student.Street,
                Building = Student.Building,
                PhoneNumber = Student.PhoneNumber,
                Rating = 0.0m,
                PhotoFile = null,
                ResumeFile = null,
            };
        }
    }
}
