using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Helpers;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Services
{
    public class ProfileIntegrationService : IProfileIntegrationService
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Applicant> applicantRepository;
        private readonly IRepository<Company> companyRepository;

        public ProfileIntegrationService(IRepository<Recruiter> recruiterRepository, IRepository<Applicant> applicantRepository, IRepository<Company> companyRepository)
        {
            this.recruiterRepository = recruiterRepository;
            this.applicantRepository = applicantRepository;
            this.companyRepository = companyRepository;
        }

        public async Task UpdateApplicant(Applicant applicant)
        {
            var previousApplicant = await applicantRepository.GetEntityAsync(applicant.Id);

            if (previousApplicant is null)
            {
                //Workarounds... 
                applicant.Address ??= new Address
                {
                    Country = "Polandia",
                    Region = "Slunsk",
                    City = "Gliwice",
                    Street = "Street",
                    Building = "Building"
                };

                applicant.PhoneNumber ??= "123456789";
                await applicantRepository.AddAsync(applicant);
            }
            else
            {
                UpdateProcessor.Update(previousApplicant, applicant);
            }
            await applicantRepository.SaveAsync();
        }

        public async Task UpdateRecruiter(Recruiter recruiter)
        {
            var previousRecruiter = await recruiterRepository.GetEntityAsync(recruiter.Id);

            if (previousRecruiter is null)
            {
                //Workarounds... 
                recruiter.PhoneNumber ??= "123456789";
                recruiter.CompanyId = (await companyRepository.GetEntitiesAsync(c => true)).First().Id;
                await recruiterRepository.AddAsync(recruiter);
            }
            else
            {
                UpdateProcessor.Update(previousRecruiter, recruiter);
            }
            await applicantRepository.SaveAsync();
        }
    }
}
