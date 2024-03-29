using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Entities;

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

            var prevApplication = await applicationRepository.GetEntityAsync(a => a.OfferId == command.OfferId && a.StudentId == command.StudentId);

            if (offer.Status != OfferStatus.Active)
            {
                throw new PostingException($"Student ({student.Id}) can only apply for active offer ({offer.Id})");
            }

            if (prevApplication is not null)
            {
                if (prevApplication.Status == ApplicationStatus.Withdrawn)
                {
                    prevApplication.Status = ApplicationStatus.Submitted;
                    await applicationRepository.SaveAsync();
                    return prevApplication.Id;
                }
                else
                {
                    throw new PostingException($"Student {command.StudentId} already applied for {command.OfferId}");
                }
            }
            else
            {
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

            return double.IsFinite(d) ? d : -1;
        }

        private double GetCoverage(IEnumerable<Schedule> availability, IEnumerable<Schedule> workTime)
        {
            var matchingTime = workTime.Sum(work => availability.Sum(av => GetCoverage(av, work)));
            var totalTime = workTime.Sum(w => w.Duration);

            logger.LogInformation("Matching time {MatchingTime} TotalTime: {TotalTime}", matchingTime, totalTime);

            if (totalTime == 0)
            {
                return 0;
            }
            var result = matchingTime / totalTime;
            return double.IsFinite(result) ? result : -1;
        }

        private double GetCoverage(Schedule availability, Schedule workTime)
        {
            int availabilityStart = (availability.DayOfWeek * 24) + availability.StartHour;
            int availabilityEnd = (availability.DayOfWeek * 24) + availability.StartHour + availability.Duration;

            int workStart = (availability.DayOfWeek * 24) + availability.StartHour;
            int workEnd = (availability.DayOfWeek * 24) + availability.StartHour + availability.Duration;

            return Math.Max(0, Math.Min(workEnd, availabilityEnd) - Math.Max(availabilityStart, workStart));
        }

        private void LogSchedules(IEnumerable<Schedule> schedules)
        {
            logger.LogInformation("Schedule: ");
            foreach (var schedule in schedules)
            {
                logger.LogInformation("In schedule: {Start} {End}", schedule.StartHour, schedule.Duration);
            }
        }
    }
}
