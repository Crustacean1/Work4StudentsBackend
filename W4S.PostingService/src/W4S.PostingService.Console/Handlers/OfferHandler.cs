using W4S.PostingService.Domain.Commands;
using W4S.ServiceBus.Attributes;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("offers")]
    public class OfferHandler : HandlerBase
    {
        private readonly PostOfferCommandHandler postOfferHandler;
        private readonly UpdateOfferCommandHandler updateOfferHandler;
        private readonly GetOffersQueryHandler getOffersQueryHandler;
        private readonly GetOfferQueryHandler getOfferQueryHandler;
        private readonly GetRecruiterOffersQueryHandler getRecruiterOffersQuery;

        public OfferHandler(PostOfferCommandHandler postOfferHandler, ILogger<OfferHandler> logger, UpdateOfferCommandHandler updateOfferHandler, GetOffersQueryHandler getOffersQueryHandler, GetOfferQueryHandler getOfferQueryHandler, GetRecruiterOffersQueryHandler getRecruiterOffersQuery) : base(logger)
        {
            this.postOfferHandler = postOfferHandler;
            this.updateOfferHandler = updateOfferHandler;
            this.getOffersQueryHandler = getOffersQueryHandler;
            this.getOfferQueryHandler = getOfferQueryHandler;
            this.getRecruiterOffersQuery = getRecruiterOffersQuery;
        }

        [BusRequestHandler("postOffer")]
        public async Task<ResponseWrapper<Guid>> OnPostOffer(PostOfferCommand command)
        {
            logger.LogInformation("Recruiter: {Recruiter} posts job offer titled: {Title}", command.RecruiterId, command.Offer.Title);

            return await ExecuteHandler(async () =>
            {
                Guid offerId = await postOfferHandler.HandleCommand(command);
                return (offerId, 201);
            });
        }

        [BusRequestHandler("updateOffer")]
        public async Task<ResponseWrapper<Guid>> OnUpdateOffer(UpdateOfferCommand command)
        {
            logger.LogInformation("Recruiter {RecruiterId} updates job offer: {OfferId}", command.RecruiterId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                await updateOfferHandler.HandleCommand(command);
                return (Guid.Empty, 204);
            });
        }

        [BusRequestHandler("getOffers")]
        public async Task<ResponseWrapper<PaginatedList<JobOffer>>> GetOfferListing(GetOffersQuery query)
        {
            logger.LogInformation("Getting all job offers");

            return await ExecuteHandler(async () =>
            {
                var offers = await getOffersQueryHandler.HandleQuery(query);
                return (offers, 200);
            });
        }

        [BusRequestHandler("getOffer")]
        public async Task<ResponseWrapper<JobOffer>> GetOffer(GetOfferQuery query)
        {
            logger.LogInformation("Getting job offer {Id}", query.OfferId);

            return await ExecuteHandler(async () =>
            {
                var offer = await getOfferQueryHandler.HandleQuery(query);
                return (offer, 200);
            });
        }

        [BusRequestHandler("getRecruiterOffers")]
        public async Task<ResponseWrapper<PaginatedList<JobOffer>>> GetRecruiterOffers(GetRecruiterOffersQuery query)
        {
            logger.LogInformation("Getting offers of recruiter: {RecruiterId}", query.RecrutierId);

            return await ExecuteHandler(async () =>
            {
                var offers = await getRecruiterOffersQuery.HandleQuery(query);
                return (offers, 200);
            });
        }
    }
}
