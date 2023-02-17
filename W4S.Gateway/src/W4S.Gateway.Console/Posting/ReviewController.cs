using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;
using W4S.ServiceBus.Abstractions;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<RecruiterController> logger;
        private readonly IClient busClient;

        public ReviewController(ILogger<RecruiterController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpDelete]
        [Route("{reviewId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteReview(Guid reviewId, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting review: {Review}", reviewId);

            var command = new DeleteReviewCommand
            {
                ReviewId = reviewId
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, DeleteReviewCommand>("reviews.deleteReview", command, cancellationToken);
            return response.Messages.Any() ? StatusCode(400, new { ErrorMessage = response.Messages.FirstOrDefault() ?? "????" }) : StatusCode(204);
        }
    }
}
