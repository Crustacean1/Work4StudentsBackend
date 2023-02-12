using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommandHandler
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Student> applicantRepository;

        public WithdrawApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Student> applicantRepository)
        {
            this.applicationRepository = applicationRepository;
            this.applicantRepository = applicantRepository;
        }

        public async Task HandleCommand(WithdrawApplicationCommand command)
        {
            var application = await applicationRepository.GetEntityAsync(command.ApplicantId);
            if (application is null)
            {
                throw new PostingException($"No application with id: {command.ApplicationId}", 400);
            }

            var applicant = await applicantRepository.GetEntityAsync(command.ApplicantId);
            if (applicant is null)
            {
                throw new PostingException($"No applicant with id: {command.ApplicationId}", 400);
            }

            if (application.Status != ApplicationStatus.Submitted)
            {
                throw new PostingException("Can only withdraw application with status 'Submitted'");
            }

            application.Status = ApplicationStatus.Withdrawn;

            await applicationRepository.SaveAsync();
        }
    }
}
