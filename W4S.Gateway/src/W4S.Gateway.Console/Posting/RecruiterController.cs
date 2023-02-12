using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Route("offers")]
        [Authorize(Roles = "Recruiter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<JobOffer>))]
        public async Task<ActionResult> GetJobOffers([FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {

            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");
            logger.LogInformation("Getting job offers of recruiter: {RecruiterId}", recruiterId);

            var query = new GetRecruiterOffersQuery
            (
                paginatedQuery.Page,
                paginatedQuery.PageSize)
            {
                RecrutierId = Guid.Parse(recruiterId)
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<JobOffer>>, GetRecruiterOffersQuery>("offer.getRecruiterOffers", query, cancellationToken);
            return UnwrapResponse(response);
        }

        private ActionResult UnwrapResponse<T>(ResponseWrapper<T> wrappedResponse)
        {
            if (wrappedResponse.Messages.Any())
            {
                return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Messages);
            }

            return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Response);
        }
    }
}
