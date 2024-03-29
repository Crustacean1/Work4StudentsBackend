using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class CloseOfferCommandHandler : CommandHandlerBase, IRequestHandler<CloseOfferCommand, Guid>
    {
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IApplicationRepository applicationRepository;

        public CloseOfferCommandHandler(IOfferRepository offerRepository, IRepository<Recruiter> recruiterRepository, IApplicationRepository applicationRepository)
        {
            this.offerRepository = offerRepository;
            this.recruiterRepository = recruiterRepository;
            this.applicationRepository = applicationRepository;
        }

        public async Task<Guid> Handle(CloseOfferCommand request, CancellationToken cancellationToken)
        {
            var recruiter = await recruiterRepository.RequireEntityAsync(request.RecruiterId);
            var offer = await offerRepository.RequireEntityAsync(request.OfferId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not close offer, recruiter {recruiter.Id} does not own offer {offer.Id}", 403);
            }

            if (offer.Status != OfferStatus.Active)
            {
                throw new PostingException($"Only active offer can be closed", 400);
            }

            var applications = await applicationRepository.GetEntitiesAsync(a => a.OfferId == request.OfferId && a.Status == ApplicationStatus.Submitted);


            foreach (var application in applications)
            {
                if (application.Status == ApplicationStatus.Submitted)
                {
                    application.Status = ApplicationStatus.Rejected;
                }
            }

            offer.Status = OfferStatus.Finished;

            await applicationRepository.SaveAsync();

            return offer.Id;
        }
    }
}
