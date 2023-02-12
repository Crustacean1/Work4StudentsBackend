using AutoMapper;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class PostOfferCommandHandler
    {
        private readonly ILogger<PostOfferCommandHandler> logger;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IRepository<Recruiter> recruiterRepository;

        private readonly IMapper mapper;

        public PostOfferCommandHandler(IRepository<JobOffer> offerRepository, ILogger<PostOfferCommandHandler> logger, IRepository<Recruiter> recruiterRepository = null)
        {
            this.offerRepository = offerRepository;
            this.logger = logger;
            this.recruiterRepository = recruiterRepository;

            var conf = new MapperConfiguration(builder => builder.CreateMap<PostOfferDto, JobOffer>());
            mapper = conf.CreateMapper();
        }

        public async Task<Guid> HandleCommand(PostOfferCommand command)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(command.RecruiterId);

            if (recruiter is null)
            {
                throw new PostingException($"JobOffer needs to be created by recruiter, no recruiter with id: {command.RecruiterId}", 400);
            }

            JobOffer offer = mapper.Map<JobOffer>(command.Offer);
            offer.Id = Guid.NewGuid();
            offer.RecruiterId = recruiter.Id;

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
