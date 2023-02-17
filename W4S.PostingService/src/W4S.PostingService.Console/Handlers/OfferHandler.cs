using W4S.PostingService.Domain.Commands;
using W4S.ServiceBus.Attributes;
using W4S.PostingService.Domain.Queries;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Dto;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("offers")]
    public class OfferHandler : HandlerBase
    {
        public OfferHandler(ILogger<OfferHandler> logger, ISender sender) : base(sender, logger)
        {
        }

        [BusRequestHandler("postOffer")]
        public async Task<ResponseWrapper<Guid>> OnPostOffer(PostOfferCommand command)
        {
            logger.LogInformation("Recruiter: {Recruiter} posts job offer titled: {Title}", command.RecruiterId, command.Offer.Title);

            return await ExecuteHandler(command, 201);
        }

        [BusRequestHandler("updateOffer")]
        public async Task<ResponseWrapper<Guid>> OnUpdateOffer(UpdateOfferCommand command)
        {
            logger.LogInformation("Recruiter {RecruiterId} updates job offer: {OfferId}", command.RecruiterId, command.OfferId);

            return await ExecuteHandler(command, 200);
        }

        [BusRequestHandler("closeOffer")]
        public async Task<ResponseWrapper<Guid>> OnCloseOffer(CloseOfferCommand command)
        {
            logger.LogInformation("Recruiter {RecruiterId} closes job offer: {OfferId}", command.RecruiterId, command.OfferId);

            return await ExecuteHandler(command, 200);
        }

        [BusRequestHandler("deleteOffer")]
        public Task<ResponseWrapper<Guid>> OnDeleteOffer(DeleteOfferCommand command)
        {
            return Task.FromResult(new ResponseWrapper<Guid>());
        }

        [BusRequestHandler("getOffers")]
        public async Task<ResponseWrapper<PaginatedList<GetOfferDto>>> GetOfferListing(GetOffersQuery query)
        {
            logger.LogInformation("Getting all job offers");

            return await ExecuteHandler(query, 200);
        }

        [BusRequestHandler("getOffer")]
        public async Task<ResponseWrapper<GetOfferDetailsDto>> GetOffer(GetOfferQuery query)
        {
            logger.LogInformation("Getting job offer {Id}", query.OfferId);

            return await ExecuteHandler(query, 200);
        }

        [BusRequestHandler("getRecruiterOffers")]
        public async Task<ResponseWrapper<PaginatedList<GetOfferDto>>> GetRecruiterOffers(GetRecruiterOffersQuery query)
        {
            logger.LogInformation("Getting offers of recruiter: {RecruiterId}", query.RecruiterId);

            return await ExecuteHandler(query, 200);
        }
    }
}
