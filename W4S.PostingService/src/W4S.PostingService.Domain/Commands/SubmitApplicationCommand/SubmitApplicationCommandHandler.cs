using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Models;
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

            LogSchedules(student.Availability);
            LogSchedules(offer.WorkingHours);

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
                Distance = GetDistance(student.Address, offer.Address),
                WorkTimeOverlap = GetCoverage(student.Availability, offer.WorkingHours)
            };

            await applicationRepository.AddAsync(application);

            await applicationRepository.SaveAsync();

            return application.Id;
        }

        private double GetDistance(Address addA, Address addB)
        {
            if (addA.Latitude is null || addA.Longitude is null) { return 0; }
            if (addB.Latitude is null || addB.Longitude is null) { return 0; }

            var lonDelta = (Math.PI * (addA.Longitude - addB.Longitude) / 180) ?? 0;
            var latDelta = (Math.PI * (addA.Latitude - addB.Latitude) / 180) ?? 0;

            var latA = (Math.PI * (addA.Latitude / 180.0)) ?? 0;
            var latB = (Math.PI * (addB.Latitude / 180.0)) ?? 0;


            var a = Math.Pow(Math.Sin(latDelta / 2), 2) + (Math.Cos(latA) * Math.Cos(latB) * Math.Pow(Math.Sin(lonDelta / 2), 2));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = 6371 * c;

            logger.LogInformation("Getting distance, computation results: {A} {B} {C}", a, c, d);

            return d;
        }

        private double GetCoverage(IEnumerable<Schedule> availability, IEnumerable<Schedule> workTime)
        {
            var matchingTime = workTime.Aggregate(0.0, (total, work) => total + availability.Sum(av => GetCoverage(av, work)));
            var totalTime = workTime.Sum(w => (w.End - w.Start).Duration().TotalHours);

            logger.LogInformation("Matching time {MatchingTime} TotalTime: {TotalTime}", matchingTime, totalTime);
            return matchingTime / totalTime;
        }

        private double GetCoverage(Schedule availability, Schedule workTime)
        {
            var start = new[] { availability.Start, workTime.Start }.Max();
            var end = new[] { availability.End, workTime.End }.Min();

            logger.LogInformation("Time piece  {start} TotalTime: {end}", start, end);

            if (start < end)
            {
                return (end - start).Duration().TotalHours;
            }

            return 0;
        }

        private void LogSchedules(IEnumerable<Schedule> schedules)
        {
            logger.LogInformation("Schedule: ");
            foreach (var schedule in schedules)
            {
                logger.LogInformation("In schedule: {Start} {End}", schedule.Start, schedule.End);
            }
        }
    }
}
