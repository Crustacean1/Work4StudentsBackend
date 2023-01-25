using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Abstractions
{
    public interface IProfileIntegrationService
    {
        Task UpdateApplicant(Applicant applicant);

        Task UpdateRecruiter(Recruiter recruiter);
    }
}
