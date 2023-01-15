using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4SRegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.Data.Entities.Universities;
using W4SRegistrationMicroservice.Data.Entities.Users;
using W4SRegistrationMicroservice.Data.Entities.Users.User_Settings;
using W4SRegistrationMicroservice.Data.Seeders.Interface;
using Microsoft.Extensions.Logging;

namespace W4SRegistrationMicroservice.Data.Seeders
{
    public class W4SUserbaseSeeder : ISeeder
    {
        private readonly W4SUserbaseDbContext _dbContext;
        private readonly IHasher _passwordHasher;
        private readonly ILogger<W4SUserbaseSeeder> _logger;

        public W4SUserbaseSeeder(
            W4SUserbaseDbContext dbContext,
            IHasher hasher,
            ILogger<W4SUserbaseSeeder> logger)
        {
            _dbContext = dbContext;
            _passwordHasher = hasher;
            _logger = logger;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    List<Roles> roles = new List<Roles>() {
                        new Roles()
                        {
                            Role = "Administrator"
                        },
                        new Roles()
                        {
                            Role = "Student"
                        },
                        new Roles()
                        {
                            Role = "Employer"
                        }
                    };

                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.UniversitiesDomains.Any())
                {
                    var domain = new Domain()
                    {
                        EmailDomain = "@polsl.pl"
                    };

                    _dbContext.UniversitiesDomains.Add(domain);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Universities.Any())
                {
                    var domain = _dbContext.UniversitiesDomains.FirstOrDefault(x => x.EmailDomain.Equals("@polsl.pl"));
                    var university = new University()
                    {
                        Name = "Politechnika Śląska",
                        EmailDomainId = domain.Id,
                    };

                    _dbContext.Universities.Add(university);
                    _dbContext.SaveChanges();
                }


                if (!_dbContext.Students.Any())
                {
                    var university = _dbContext.Universities.FirstOrDefault(x => x.Name.Equals("Politechnika Śląska"));

                    var students = new List<Student>()
                    {
                        new Student() {
                        EmailAddress = "janek.tumanek@polsl.pl",
                        PasswordHash = _passwordHasher.HashText("NOTHASHED:DDD"),
                        Name = "Jan",
                        SecondName = "Man",
                        Surname = "Tuman",
                        UniversityId = university.Id,
                        RoleId = _dbContext.Roles.First(s => s.Role.Equals("Student")).Id,
                        PhoneNumber = "2137"
                        },
                        new Student()
                        {
                        EmailAddress = "janek.tumanek@polsl.pl",
                        PasswordHash = _passwordHasher.HashText("NOTHASHED:DDD"),
                        Name = "Jan",
                        Surname = "Tuman",
                        PhoneNumber = "729001234",
                        UniversityId = university.Id,
                        RoleId = _dbContext.Roles.First(s => s.Role.Equals("Student")).Id
                        }
                    };

                    _dbContext.Students.AddRange(students);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Companies.Any())
                {
                    var company = new Company()
                    {
                        NIP = "5283121250",
                        Name = "Empty firm in Poland"
                    };

                    _dbContext.Companies.Add(company);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Employers.Any())
                {
                    var company = _dbContext.Companies.FirstOrDefault(x => x.NIP.Equals("5283121250"));

                    var employer = new Employer()
                    {
                        EmailAddress = "someEmployer@gmail.com",
                        Name = "Adam",
                        SecondName = "Szef",
                        Surname = "Małysz",
                        PasswordHash = _passwordHasher.HashText("NOTHASHED:DDD"),
                        PositionName = "Majster HR",
                        CompanyId = company.Id,
                        RoleId = _dbContext.Roles.First(s => s.Role.Equals("Employer")).Id,
                        PhoneNumber = "2137"
                    };

                    _dbContext.Employers.Add(employer);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Administrators.Any())
                {
                    var admin = new Administrator()
                    {
                        EmailAddress = "JoeMama@gmail.com",
                        PasswordHash = _passwordHasher.HashText("U wish u knew."),
                        Name = "Admin",
                        Surname = "Joe",
                        RoleId = _dbContext.Roles.First(s => s.Role.Equals("Administrator")).Id,
                        PhoneNumber = "2137"
                    };

                    _dbContext.Administrators.Add(admin);
                    _dbContext.SaveChanges();
                }
            }
            else
            {
                _logger.LogInformation("Can't connect to the database.");
            }
        }
    }
}
