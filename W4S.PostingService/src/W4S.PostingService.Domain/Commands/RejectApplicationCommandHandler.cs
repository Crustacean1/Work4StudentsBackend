using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class RejectApplicationCommandHandler : CommandHandlerBase, IRequestHandler<RejectApplicationCommand, Guid>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly IOfferRepository offerRepository;

        public RejectApplicationCommandHandler(IApplicationRepository applicationRepository, IRepository<Recruiter> recruiterRepository, IOfferRepository offerRepository)
        {
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;
            this.offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(RejectApplicationCommand command, CancellationToken cancellationToken)
        {
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);
            var application = await GetEntity(applicationRepository, command.ApplicationId);
            var offer = await GetEntity(offerRepository, application.OfferId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Couldn't reject application {application.Id}, recruiter {recruiter.Id} does not own offer {offer.Id}", 403);
            }

            if (application.Status != ApplicationStatus.Submitted)
            {
                throw new PostingException($"Only submitted application can be rejected ({command.ApplicationId})");
            }
            application.Status = ApplicationStatus.Rejected;

            await applicationRepository.SaveAsync();

            return application.Id;
        }
    }
}
