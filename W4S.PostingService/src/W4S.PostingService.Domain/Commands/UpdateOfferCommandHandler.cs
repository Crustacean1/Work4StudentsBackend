using W4S.PostingService.Domain.Entities;
using AutoMapper;
using W4S.PostingService.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Models.Transfer;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferCommandHandler : CommandHandlerBase, IRequestHandler<UpdateOfferCommand, Guid>
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly ILogger<UpdateOfferCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly AddressApi addressApi;

        public UpdateOfferCommandHandler(IOfferRepository offerRepository, ILogger<UpdateOfferCommandHandler> logger, IRepository<Recruiter> recruiterRepository, IApplicationRepository applicationRepository, AddressApi addressApi)
        {
            MapperConfiguration conf = new(builder => builder.CreateMap<UpdateOfferDto, JobOffer>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            mapper = conf.CreateMapper();
            this.offerRepository = offerRepository;
            this.logger = logger;
            this.recruiterRepository = recruiterRepository;
            this.applicationRepository = applicationRepository;
            this.addressApi = addressApi;
        }

        public async Task<Guid> Handle(UpdateOfferCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating job offer: {OfferId} with update: {Update}", command.Offer, JsonSerializer.Serialize(command.Offer));

            var newOffer = command.Offer;
            var previousOffer = await GetEntity(offerRepository, command.OfferId);
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);

            if (previousOffer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not update offer, recruiter {recruiter.Id} does not own offer {previousOffer.Id}", 403);
            }

            mapper.Map(newOffer, previousOffer);
            await addressApi.UpdateAddress(previousOffer.Address);

            await offerRepository.SaveAsync();

            var applications = await applicationRepository.GetApplicationsWithEntities(a => a.OfferId == previousOffer.Id);

            foreach (var application in applications)
            {
                application.ComputeDistance();
            }

            await applicationRepository.SaveAsync();
            return previousOffer.Id;
        }
    }
}
