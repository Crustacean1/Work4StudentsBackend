using W4S.PostingService.Domain.Entities;
using AutoMapper;
using W4S.PostingService.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Domain.Commands
{
    public class UpdateOfferCommandHandler
    {
        private readonly ILogger<UpdateOfferCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IRepository<JobOffer> offerRepository;

        public UpdateOfferCommandHandler(IRepository<JobOffer> offerRepository, ILogger<UpdateOfferCommandHandler> logger)
        {
            MapperConfiguration conf = new(builder => builder.CreateMap<UpdateOfferDto, JobOffer>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            mapper = conf.CreateMapper();
            this.offerRepository = offerRepository;
            this.logger = logger;
        }

        public async Task HandleCommand(UpdateOfferCommand command)
        {
            logger.LogInformation("Updating job offer: {OfferId} with update: {Update}", command.Offer, JsonSerializer.Serialize(command.Offer));

            var newOffer = command.Offer;
            var previousOffer = await offerRepository.GetEntityAsync(command.OfferId);

            if (previousOffer is null)
            {
                throw new PostingException($"Could not update job offer with id: {command.OfferId} , job doesn't exist");
            }

            mapper.Map(newOffer, previousOffer);

            await offerRepository.SaveAsync();
        }
    }
}
