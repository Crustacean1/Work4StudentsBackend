using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Models.Commands;
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
        [Authorize(Roles = "Student")]
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
        [Authorize(Roles = "Student")]
        [Route("{applicationId}/withdraw")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<ActionResult> WithdrawApplication([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var studentId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new WithdrawApplicationCommand
            {
                StudentId = Guid.Parse(studentId),
                ApplicationId = applicationId
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, WithdrawApplicationCommand>("applications.withdrawApplication", command, cancellationToken);

            return UnwrapResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        [Route("{applicationId}/accept")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<ActionResult> AcceptApplication([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new AcceptApplicationCommand
            {
                RecruiterId = Guid.Parse(userId),
                ApplicationId = applicationId
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, AcceptApplicationCommand>("applications.acceptApplication", command, cancellationToken);

            return UnwrapResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        [Route("{applicationId}/reject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<ActionResult> RejectApplication([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new RejectApplicationCommand
            {
                RecruiterId = Guid.Parse(userId),
                ApplicationId = applicationId
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, RejectApplicationCommand>("applications.rejectApplication", command, cancellationToken);

            return UnwrapResponse(response);
        }

        [HttpPost]
        [Authorize]
        [Route("{applicationId}/reviews")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<ActionResult> PostReview([FromRoute] Guid applicationId, [FromBody] PostReviewDto review, CancellationToken cancellationToken)
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

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("{offerId}")]
        public async Task<ActionResult> DeleteApplication([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var command = new DeleteOfferCommand
            {
                OfferId = offerId,
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, DeleteOfferCommand>("offers.deleteOffer", command, cancellationToken);
            return StatusCode(204);
        }

        private ActionResult UnwrapResponse<T>(ResponseWrapper<T> wrappedResponse)
        {
            if (wrappedResponse.Messages?.Any() ?? false)
            {
                var aggregate = wrappedResponse.Messages.Aggregate("", (t, m) => (t + "\n" + m));
                return StatusCode(wrappedResponse.ResponseCode, new { ErrorMessages = wrappedResponse.Messages });
            }

            return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Response);
        }
    }
}
