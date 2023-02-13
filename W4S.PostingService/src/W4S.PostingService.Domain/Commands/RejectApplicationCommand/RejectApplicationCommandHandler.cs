using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class RejectApplicationCommandHandler : CommandHandlerBase, IRequestHandler<RejectApplicationCommand, Unit>
    {
        private IRepository<Recruiter> recruiterRepository;
        private IRepository<Application> applicationRepository;
        private IRepository<JobOffer> offerRepository;

        public RejectApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Recruiter> recruiterRepository, IRepository<JobOffer> offerRepository)
        {
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;
            this.offerRepository = offerRepository;
        }

        public async Task<Unit> Handle(RejectApplicationCommand command, CancellationToken cancellationToken)
        {
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);
            var application = await GetEntity(applicationRepository, command.ApplicationId);
            var offer = await GetEntity(offerRepository, application.OfferId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Couldn't reject application {application.Id}, recruiter {recruiter.Id} does not own offer {offer.Id}", 400);
            }

            if (application.Status != ApplicationStatus.Submitted)
            {
                throw new PostingException($"Only submitted application can be rejected ({command.ApplicationId})");
            }
            application.Status = ApplicationStatus.Rejected;

            await applicationRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
