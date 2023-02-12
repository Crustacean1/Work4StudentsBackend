using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class SubmitApplicationCommandHandler
    {
        private readonly IRepository<Student> applicantRepository;
        private readonly IRepository<Application> applicationRepository;

        public SubmitApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Student> applicantRepository)
        {
            this.applicationRepository = applicationRepository;
            this.applicantRepository = applicantRepository;
        }

        public async Task<Guid> HandleCommand(SubmitApplicationCommand command)
        {
            var applicant = await applicantRepository.GetEntityAsync(command.StudentId);
            if (applicant is null)
            {
                throw new PostingException($"No applicant with id: {command.StudentId} found");
            }

            var offer = await applicantRepository.GetEntityAsync(command.OfferId);
            if (offer is null)
            {
                throw new PostingException($"No offer with id: {command.OfferId}");
            }

            var application = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = offer.Id,
                StudentId = applicant.Id,
                LastChanged = DateTime.UtcNow,
                Status = ApplicationStatus.Submitted,
                Message = command.Application.Message
            };

            await applicationRepository.AddAsync(application);

            await applicationRepository.SaveAsync();

            return application.Id;
        }
    }
}
