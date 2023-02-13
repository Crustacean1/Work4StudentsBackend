using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class SubmitApplicationCommandHandler : CommandHandlerBase, IRequestHandler<SubmitApplicationCommand, Guid>
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IRepository<Application> applicationRepository;

        public SubmitApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Student> studentRepository, IRepository<JobOffer> offerRepository)
        {
            this.studentRepository = studentRepository;
            this.studentRepository = studentRepository;
            this.offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(SubmitApplicationCommand command, CancellationToken cancellationToken)
        {
            var student = await GetEntity(studentRepository, command.StudentId);
            var offer = await GetEntity(offerRepository, command.OfferId);

            var application = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = offer.Id,
                StudentId = student.Id,
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
