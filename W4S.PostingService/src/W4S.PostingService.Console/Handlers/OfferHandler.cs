using W4S.PostingService.Domain.Commands;
using W4S.ServiceBus.Attributes;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Entities;
using MediatR;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("offers")]
    public class OfferHandler : HandlerBase
    {
        private readonly ISender sender;

        public OfferHandler(ILogger<OfferHandler> logger, ISender sender) : base(logger)
        {
            this.sender = sender;
        }

        [BusRequestHandler("postOffer")]
        public async Task<ResponseWrapper<Guid>> OnPostOffer(PostOfferCommand command)
        {
            logger.LogInformation("Recruiter: {Recruiter} posts job offer titled: {Title}", command.RecruiterId, command.Offer.Title);

            return await ExecuteHandler(async () =>
            {
                Guid offerId = await sender.Send(command);
                return (offerId, 201);
            });
        }

        [BusRequestHandler("updateOffer")]
        public async Task<ResponseWrapper<Guid>> OnUpdateOffer(UpdateOfferCommand command)
        {
            logger.LogInformation("Recruiter {RecruiterId} updates job offer: {OfferId}", command.RecruiterId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                _ = await sender.Send(command);
                return (Guid.Empty, 204);
            });
        }

        [BusRequestHandler("getOffers")]
        public async Task<ResponseWrapper<PaginatedList<GetOfferDto>>> GetOfferListing(GetOffersQuery query)
        {
            logger.LogInformation("Getting all job offers");

            return await ExecuteHandler(async () =>
            {
                var offers = await sender.Send(query);
                return (offers, 200);
            });
        }

        [BusRequestHandler("getOffer")]
        public async Task<ResponseWrapper<GetOfferDto>> GetOffer(GetOfferQuery query)
        {
            logger.LogInformation("Getting job offer {Id}", query.OfferId);

            return await ExecuteHandler(async () =>
            {
                var offer = await sender.Send(query);
                return (offer, 200);
            });
        }

        [BusRequestHandler("getRecruiterOffers")]
        public async Task<ResponseWrapper<PaginatedList<GetOfferDto>>> GetRecruiterOffers(GetRecruiterOffersQuery query)
        {
            logger.LogInformation("Getting offers of recruiter: {RecruiterId}", query.RecruiterId);

            return await ExecuteHandler(async () =>
            {
                var offers = await sender.Send(query);
                return (offers, 200);
            });
        }
    }
}
