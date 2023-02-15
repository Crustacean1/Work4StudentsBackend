using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class SubmitApplicationCommandHandler : CommandHandlerBase, IRequestHandler<SubmitApplicationCommand, Guid>
    {
        private ILogger<SubmitApplicationCommandHandler> logger;
        private readonly IRepository<Student> studentRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IRepository<Application> applicationRepository;

        public SubmitApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Student> studentRepository, IOfferRepository offerRepository, ILogger<SubmitApplicationCommandHandler> logger)
        {
            this.applicationRepository = applicationRepository;
            this.studentRepository = studentRepository;
            this.offerRepository = offerRepository;
            this.logger = logger;
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

            GetProximity(student.Address, offer.Address);

            return application.Id;
        }

        private int GetProximity(Address a, Address b)
        {
            var categories = new List<string> { "Country", "Region", "City", "Street" };


            var distance = categories.FirstOrDefault(c =>
            {
                var type = typeof(Address).GetProperty(c)!;
                if (type is null)
                {
                    return false;
                }
                return type.GetValue(a) != type.GetValue(b);
            });

            logger.LogInformation("{Distance}", distance);
            return 0;
        }
    }
}
