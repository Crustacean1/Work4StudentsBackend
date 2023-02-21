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
        public Company Company1 { get; set; }
        public Company Company2 { get; set; }
        public Company Company3 { get; set; }
        public Company Company4 { get; set; }
        public Company Company5 { get; set; }
        public Company Company6 { get; set; }
        public Company Company7 { get; set; }
        public Company Company8 { get; set; }
        public Company Company9 { get; set; }
        public List<Company> Companies { get; set; }
        public Administrator Admin { get; set; }

        public Domain EmailDomain { get; set; }

        //public List<Domain> UniversityDomains { get; set; }

        public Domain Domain1 { get; set; }
        public Domain Domain2 { get; set; }
        public Domain Domain3 { get; set; }
        public Domain Domain4 { get; set; }

        //public List<University> Universities { get; set; }
        public University University1 { get; set; }
        public University University2 { get; set; }
        public University University3 { get; set; }
        public University University4 { get; set; }

        public UserbaseSeeder()
        {
            Seed();
        }

        public void Seed()
        {

            Domain1 = new Domain()
            {
                Id = Guid.NewGuid(),
                EmailDomain = "@student.agh.edu.pl"
            };
            Domain2 = new Domain()
            {
                Id = Guid.NewGuid(),
                EmailDomain = "@student.polsl.pl"
            };
            Domain3 = new Domain()
            {
                Id = Guid.NewGuid(),
                EmailDomain = "@student.uek.krakow.pl"
            };
            Domain4 = new Domain()
            {
                Id = Guid.NewGuid(),
                EmailDomain = "@student.uj.edu.pl"
            };

            University1 = new University()
            {
                Id = Guid.NewGuid(),
                Name = "AGH University of Science and Technology",
                EmailDomainId = Domain1.Id
            };
            University2 = new University()
            {
                Id = Guid.NewGuid(),
                Name = "Silesian Technical University of Gliwice",
                EmailDomainId = Domain2.Id
            };
            University3 = new University()
            {
                Id = Guid.NewGuid(),
                Name = "Cracow University of Economics",
                EmailDomainId = Domain3.Id
            };
            University4 = new University()
            {
                Id = Guid.NewGuid(),
                Name = "Jagellonian University",
                EmailDomainId = Domain4.Id
            };

            Company1 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "1 A PHARMA GMBH SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ ODDZIAŁ W POLSCE W LIKWIDACJI",
                NIP = "1070008183"
            };
            Company2 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "1) DIAMENT JOLANTA JAROSZEK 2) Jolanta Jaroszek wspólnik spółki cywilnej RJ CAR",
                NIP = "1130103940"
            };
            Company3 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Avanti Capital Leasing",
                NIP = "759114060"
            };
            Company4 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Agencja Ochrony Pracy Kwiatkowska",
                NIP = "951643196"
            };
            Company5 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "ACHIMA POLSTERMOBELFABRIK GMBH,SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ",
                NIP = "1040000426"
            };
            Company6 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "AUDACON SPÓŁKA AKCYJNA ODDZIAŁ W POLSCE",
                NIP = "1050000244"
            };
            Company7 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "MAAS HOLDING GMBH (SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ) ODDZIAŁ W POLSCE",
                NIP = "1010000108"
            };
            Company8 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Medical Care24 Ewelina Dąbrowska",
                NIP = "1181816779"
            };
            Company9 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Willa Avita Joanna Zięba",
                NIP = "9690207610"
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

        }
    }
}
