using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Abstractions;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly IClient busClient;

        public StudentController(ILogger<StudentController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpGet]
        [Route("applications")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<JobOffer>))]
        public async Task<ActionResult> GetJobOffers([FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            var studentId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");
            var query = new GetStudentApplicationsQuery
            (
                paginatedQuery.Page,
                paginatedQuery.PageSize)
            {
                StudentId = Guid.Parse(studentId)
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<JobOffer>>, GetStudentApplicationsQuery>("offer.getStudentApplications", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Route("{studentId}/reviews")]
        [Authorize]
        public async Task<ActionResult> GetReviews([FromRoute] Guid studentId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting page {Page} with page size: {PageSize} reviews for student {Id}", paginatedQuery.Page, paginatedQuery.PageSize, studentId);

            var query = new GetStudentReviewsQuery
            {
                PageSize = paginatedQuery.PageSize,
                Page = paginatedQuery.Page,
                StudentId = studentId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<ApplicationReview>>, GetStudentReviewsQuery>("reviews.getStudentReviews", query, cancellationToken);
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
