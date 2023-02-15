using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class SubmitApplicationCommandHandler : CommandHandlerBase, IRequestHandler<SubmitApplicationCommand, Guid>
    {
        private ILogger<SubmitApplicationCommandHandler> logger;
        private readonly IRepository<Student> studentRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IApplicationRepository applicationRepository;

        public SubmitApplicationCommandHandler(IApplicationRepository applicationRepository, IRepository<Student> studentRepository, IOfferRepository offerRepository, ILogger<SubmitApplicationCommandHandler> logger)
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

            var prevApplications = await applicationRepository.GetEntityAsync(a => a.OfferId == command.OfferId && a.StudentId == command.StudentId);
            if (prevApplications is not null)
            {
                throw new PostingException($"Student {command.StudentId} already applied for {command.OfferId}");
            }

            var application = new Application
            {
                Id = Guid.NewGuid(),
                OfferId = offer.Id,
                StudentId = student.Id,
                LastChanged = DateTime.UtcNow,
                Status = ApplicationStatus.Submitted,
                Message = command.Application.Message,
                Distance = GetDistance(student.Address, offer.Address)
            };

            await applicationRepository.AddAsync(application);

            await applicationRepository.SaveAsync();

            return application.Id;
        }

        private double GetDistance(Address addA, Address addB)
        {
            if (addA.Latitude is null || addA.Longitude is null) { return 0; }
            if (addB.Latitude is null || addB.Longitude is null) { return 0; }

            var lonDelta = (Math.PI * (addA.Longitude - addB.Longitude / 180)) ?? 0;
            var latDelta = (Math.PI * (addA.Latitude - addB.Latitude / 180)) ?? 0;

            var latA = (Math.PI * (addA.Latitude / 180)) ?? 0;
            var latB = (Math.PI * (addB.Latitude / 180)) ?? 0;


            var a = Math.Pow(Math.Sin(latDelta / 2), 2) + (Math.Cos(latA) * Math.Cos(latB) * Math.Pow(Math.Cos(lonDelta / 2), 2));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = 6_371 * c;

            logger.LogInformation("Getting distance, computaion results: {A} {B} {C}", a, c, d);

            return d;
        }
    }
}
