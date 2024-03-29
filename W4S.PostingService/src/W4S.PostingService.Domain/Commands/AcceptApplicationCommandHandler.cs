using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class AcceptApplicationCommandHandler : CommandHandlerBase, IRequestHandler<AcceptApplicationCommand, Guid>
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IOfferRepository offerRepository;

        public AcceptApplicationCommandHandler(IRepository<Recruiter> recruiterRepository, IApplicationRepository applicationRepository, IOfferRepository offerRepository)
        {
            this.recruiterRepository = recruiterRepository;
            this.applicationRepository = applicationRepository;
            this.offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(AcceptApplicationCommand request, CancellationToken cancellationToken)
        {

            var recruiter = await GetEntity(recruiterRepository, request.RecruiterId);
            var application = await GetEntity(applicationRepository, request.ApplicationId);
            var offer = await GetEntity(offerRepository, application.OfferId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not accept application, recruiter {recruiter.Id} does not own offer {offer.Id}");
            }

            if (application.Status != ApplicationStatus.Submitted)
            {
                throw new PostingException($"Only submitted application can be accepted ({request.ApplicationId}) current status: {Enum.GetName(typeof(ApplicationStatus), application.Status)}");
            }

            application.Status = ApplicationStatus.Accepted;

            await applicationRepository.SaveAsync();

            return application.Id;
        }
    }
}
