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
        public List<Company> Companies { get; set; }
        public Student Student { get; set; }
        public Employer Employer { get; set; }
        public Administrator Admin { get; set; }

        public Domain EmailDomain { get; set; }

        public List<Domain> UniversityDomains { get; set; }
        public List<University> Universities { get; set; }
        public EmployerProfile EmployerProfile { get; set;}
        public StudentProfile StudentProfile { get; set;}

        public UserbaseSeeder()
        {
            Seed();
        }

        public void Seed()
        {

            UniversityDomains = new List<Domain>() {
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = "@student.agh.edu.pl"
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = "@student.polsl.pl"
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = "@student.uek.krakow.pl"
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = "@student.uj.edu.pl"
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
                new Domain()
                {
                    Id = Guid.NewGuid(),
                    EmailDomain = ""
                },
            };

            Universities = new List<University>()
            {
                new University()
                {
                    Id = Guid.NewGuid(),
                    Name = "AGH University of Science and Technology",
                    EmailDomainId = UniversityDomains[0].Id
                },
                new University()
                {
                    Id = Guid.NewGuid(),
                    Name = "Silesian Technical University of Gliwice",
                    EmailDomainId = UniversityDomains[1].Id
                },
                new University()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cracow University of Economics",
                    EmailDomainId = UniversityDomains[2].Id
                },
                new University()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jagellonian University",
                    EmailDomainId = UniversityDomains[3].Id
                }
            };

            Companies = new List<Company>()
            {
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "1 A PHARMA GMBH SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ ODDZIAŁ W POLSCE W LIKWIDACJI",
                    NIP = "1070008183"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "1) DIAMENT JOLANTA JAROSZEK 2) Jolanta Jaroszek wspólnik spółki cywilnej RJ CAR",
                    NIP = "1130103940"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "Avanti Capital Leasing",
                    NIP = "759114060"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "Agencja Ochrony Pracy Kwiatkowska",
                    NIP = "951643196"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "ACHIMA POLSTERMOBELFABRIK GMBH,SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ\"ODDZIAŁ W POLSCE\" W LIKWIDACJI",
                    NIP = "1040000426"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "AUDACON SPÓŁKA AKCYJNA ODDZIAŁ W POLSCE",
                    NIP = "1050000244"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "MAAS HOLDING GMBH (SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ) ODDZIAŁ W POLSCE",
                    NIP = "1010000108"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Care24 Ewelina Dąbrowska",
                    NIP = "1181816779"
                },
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = "Willa Avita Joanna Zięba",
                    NIP = "9690207610"
                }
            };


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
                CompanyName = Company.Name,
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
