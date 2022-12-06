using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4SRegistrationMicroservice.Data.DbContexts;
using W4SRegistrationMicroservice.Data.Entities;
using W4SRegistrationMicroservice.Data.Entities.Universities;
using W4SRegistrationMicroservice.Data.Entities.Users;
using W4SRegistrationMicroservice.Data.Seeders.Interface;

namespace W4SRegistrationMicroservice.Data.Seeders
{
    public class W4SUserbaseSeeder : ISeeder
    {
        private readonly W4SUserbaseDbContext _dbContext;

        public W4SUserbaseSeeder(W4SUserbaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
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

                    var student = new Student()
                    {
                        EmailAddress = "janek.tumanek@polsl.pl",
                        PasswordHash = "NOTHASHED:DDD",
                        Name = "Jan",
                        Surname = "Tuman",
                        UniversityId = university.Id
                    };

                    _dbContext.Students.Add(student);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Companies.Any())
                {
                    var company = new Company()
                    {
                        NIP = "3563648589",
                        Name = "Empty firm in Poland"
                    };

                    _dbContext.Companies.Add(company);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Employers.Any())
                {
                    var company = _dbContext.Companies.FirstOrDefault(x => x.NIP.Equals("3563648589"));

                    var employer = new Employer()
                    {
                        EmailAddress = "someEmployer@gmail.com",
                        Name = "Adam",
                        Surname = "Małysz",
                        PasswordHash = "NOTHASHED:DDD",
                        PositionName = "Majster HR",
                        CompanyId = company.Id
                    };

                    _dbContext.Employers.Add(employer);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Administrators.Any())
                {
                    var admin = new Administrator()
                    {
                        EmailAddress = "JoeMama@gmail.com",
                        PasswordHash = "U wish u knew.",
                        Name = "Admin",
                        Surname = "Joe",
                    };

                    _dbContext.Administrators.Add(admin);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
