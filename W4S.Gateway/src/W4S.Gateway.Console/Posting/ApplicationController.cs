using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.ServiceBus.Abstractions;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> logger;
        private readonly IClient busClient;

        public ApplicationController(ILogger<ApplicationController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPost]
        [Route("apply/{offerId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
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

        [HttpPost]
        [Route("withdraw/{applicationId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<ActionResult> WithdrawApplication([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var studentId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            return StatusCode(201, Guid.Empty);
        }


        [HttpPost]
        [Route("{applicationId}/reviews")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [Authorize]
        public async Task<ActionResult> PostReview([FromRoute] Guid applicationId, [FromBody] ApplicationReview review, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No userId claim specified");
            logger.LogInformation("Recruiter {RecruiterId} reviews offer {Application}", recruiterId, applicationId);

            var command = new ReviewApplicationCommand
            {
                RecruiterId = Guid.Parse(recruiterId),
                ApplicationId = applicationId,
                Review = review
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, ReviewApplicationCommand>("reviews.reviewApplication", command, cancellationToken);

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
