using W4S.PostingService.Domain.Entities;
using AutoMapper;
using W4S.PostingService.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferCommandHandler : CommandHandlerBase, IRequestHandler<UpdateOfferCommand, Guid>
    {
        private readonly ILogger<UpdateOfferCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;
        private readonly IRepository<Recruiter> recruiterRepository;

        public UpdateOfferCommandHandler(IOfferRepository offerRepository, ILogger<UpdateOfferCommandHandler> logger, IRepository<Recruiter> recruiterRepository)
        {
            MapperConfiguration conf = new(builder => builder.CreateMap<UpdateOfferDto, JobOffer>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            mapper = conf.CreateMapper();
            this.offerRepository = offerRepository;
            this.logger = logger;
            this.recruiterRepository = recruiterRepository;
        }

        public async Task<Guid> Handle(UpdateOfferCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating job offer: {OfferId} with update: {Update}", command.Offer, JsonSerializer.Serialize(command.Offer));

            var newOffer = command.Offer;
            var previousOffer = await GetEntity(offerRepository, command.OfferId);
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);

            if (previousOffer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not update offer, recruiter {recruiter.Id} does not own offer {previousOffer.Id}", 400);
            }

            mapper.Map(newOffer, previousOffer);

            await offerRepository.SaveAsync();
            return previousOffer.Id;
        }
    }
}
