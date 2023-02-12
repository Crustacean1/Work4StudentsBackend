using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Queries;
using W4S.PostingService.Domain.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/offer")]
    public class JobController : ControllerBase
    {

        private readonly ILogger<JobController> logger;
        private readonly IClient busClient;

        public JobController(ILogger<JobController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<string>))]
        public async Task<ActionResult> PostOffer([FromBody] PostOfferDto offer, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new PostOfferCommand { Offer = offer, RecruiterId = Guid.Parse(recruiterId) };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, PostOfferCommand>("offers.postOffer", command, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "Recruiter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [Route("{id}")]
        public async Task<ActionResult> UpdateOffer([FromRoute] Guid id, [FromBody] UpdateOfferDto update, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");
            var command = new UpdateOfferCommand
            {
                OfferId = id,
                RecruiterId = Guid.Parse(recruiterId),
                Offer = update
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, UpdateOfferCommand>("offers.updateOffer", command, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<JobOffer>))]
        public async Task<ActionResult> GetJobOffers([FromQuery] PaginatedQuery query, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<JobOffer>>, PaginatedQuery>("offers.getOffers", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Route("{offerId}")]
        public async Task<ActionResult> GetJobOffer([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var query = new GetOfferQuery
            {
                OfferId = offerId
            };
            var response = await busClient.SendRequest<ResponseWrapper<JobOffer>, GetOfferQuery>("offers.getOffer", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPost]
        [Route("apply/{offerId}")]
        public async Task<ActionResult> SubmitApplication([FromRoute] Guid offerId, SubmitApplicationDto applicationDto, CancellationToken cancellationToken)
        {
            var studentId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new SubmitApplicationCommand
            {
                OfferId = offerId,
                StudentId = Guid.Parse(studentId),
                Application = applicationDto
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, SubmitApplicationCommand>("applications.submitApplication", command, cancellationToken);
            return UnwrapResponse(response);
        }

        private ActionResult UnwrapResponse<T>(ResponseWrapper<T> wrappedResponse)
        {
            if (wrappedResponse.Messages?.Any() ?? false)
            {
                return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Messages);
            }

            return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Response);
        }
    }
}
