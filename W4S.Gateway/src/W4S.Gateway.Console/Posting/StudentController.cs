using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;
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

        [HttpGet("{studentId}/offers")]
        [Route("applications")]
        [Authorize(Roles = "Student,Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetApplicationDto>))]
        public async Task<ActionResult> GetJobOffers([FromRoute] Guid studentId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            var currentUserId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");
            var currentUserRole = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? throw new InvalidOperationException("No user role claim defined");

            if(Guid.Parse(currentUserId) != studentId || currentUserRole != "Administrator")
            {
                return Forbid();
            }

            var query = new GetStudentApplicationsQuery
            {
                Page = paginatedQuery.Page,
                PageSize = paginatedQuery.PageSize,
                StudentId = studentId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetApplicationDto>>, GetStudentApplicationsQuery>("applications.getStudentApplications", query, cancellationToken);
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

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<ApplicationReviewDto>>, GetStudentReviewsQuery>("reviews.getStudentReviews", query, cancellationToken);
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
