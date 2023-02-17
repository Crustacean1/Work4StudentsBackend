using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Commands
{
    public class PostOfferCommandHandler : CommandHandlerBase, IRequestHandler<PostOfferCommand, Guid>
    {
        private readonly ILogger<PostOfferCommandHandler> logger;
        private readonly IOfferRepository offerRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly AddressApi addressApi;

        private readonly IMapper mapper;

        public PostOfferCommandHandler(IOfferRepository offerRepository, ILogger<PostOfferCommandHandler> logger, IRepository<Recruiter> recruiterRepository, AddressApi addressApi)
        {
            this.offerRepository = offerRepository;
            this.logger = logger;
            this.recruiterRepository = recruiterRepository;

            var conf = new MapperConfiguration(builder => builder.CreateMap<PostOfferDto, JobOffer>());
            mapper = conf.CreateMapper();
            this.addressApi = addressApi;
        }

        public async Task<Guid> Handle(PostOfferCommand command, CancellationToken cancellationToken)
        {
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);

            JobOffer offer = mapper.Map<JobOffer>(command.Offer);
            if (offer.PayRange.Max < offer.PayRange.Min)
            {
                throw new PostingException("Invalid pay range, max must be below min", 400);
            }

            offer.Id = Guid.NewGuid();
            offer.RecruiterId = recruiter.Id;
            offer.CreationDate = DateTime.UtcNow;

            await addressApi.UpdateAddress(offer.Address);

            try
            {
                await offerRepository.AddAsync(offer);
                await offerRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("Error in handler: {Error}\n{InnerError}\n{StackTrace}", ex.Message, ex.InnerException?.Message ?? "<No inner exception>", ex.StackTrace);
            }

            return offer.Id;
        }
    }
}
