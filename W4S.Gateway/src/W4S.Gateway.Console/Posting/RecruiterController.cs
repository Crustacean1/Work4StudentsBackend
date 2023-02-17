using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Abstractions;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/recruiter")]
    public class RecruiterController : ControllerBase
    {
        private readonly ILogger<RecruiterController> logger;
        private readonly IClient busClient;

        public RecruiterController(ILogger<RecruiterController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpGet]
        [Route("{recruiterId}/offers/")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetOfferDto>))]
        public async Task<ActionResult> GetJobOffers([FromRoute] Guid recruiterId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting job offers of recruiter: {RecruiterId}", recruiterId);

            var query = new GetRecruiterOffersQuery
            {
                Page = paginatedQuery.Page,
                PageSize = paginatedQuery.PageSize,
                RecruiterId = recruiterId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetOfferDto>>, GetRecruiterOffersQuery>("offers.getRecruiterOffers", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Route("{recruiterId}/reviews")]
        [Authorize]
        public async Task<ActionResult> GetReviews([FromRoute] Guid recruiterId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting page {Page} with page size: {PageSize} reviews for recruiter {Id}", paginatedQuery.Page, paginatedQuery.PageSize, recruiterId);

            var query = new GetRecruiterReviewsQuery
            {
                PageSize = paginatedQuery.PageSize,
                Page = paginatedQuery.Page,
                RecruiterId = recruiterId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<OfferReviewDto>>, GetRecruiterReviewsQuery>("reviews.getRecruiterReviews", query, cancellationToken);
            return UnwrapResponse(response);
        }


        private ActionResult UnwrapResponse<T>(ResponseWrapper<T> wrappedResponse)
        {
            if (wrappedResponse.Messages.Any())
            {
                var aggregate = wrappedResponse.Messages.Aggregate("", (t, m) => (t + "\n" + m));
                return StatusCode(wrappedResponse.ResponseCode, new { ErrorMessage = wrappedResponse.Messages });
            }

            return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Response);
        }
    }
}
