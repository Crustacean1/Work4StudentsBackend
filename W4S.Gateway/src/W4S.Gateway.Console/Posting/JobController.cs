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
    [Route("api/offers")]
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
        [Authorize]
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
        [Route("{offerId}")]
        public async Task<ActionResult> UpdateOffer([FromRoute] Guid offerId, [FromBody] UpdateOfferDto update, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");
            var command = new UpdateOfferCommand
            {
                OfferId = offerId,
                RecruiterId = Guid.Parse(recruiterId),
                Offer = update
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, UpdateOfferCommand>("offers.updateOffer", command, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetOffersDto>))]
        public async Task<ActionResult> GetJobOffers([FromQuery] OfferQuery query, CancellationToken cancellationToken)
        {
            var offersQuery = new GetOffersQuery(query.Page, query.PageSize)
            {
                Keywords = query.Keywords?.Split(" ", StringSplitOptions.TrimEntries) ?? new string[] { },
                Categories = query.Categories?.Split(" ", StringSplitOptions.TrimEntries) ?? new string[] { },
            };
            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetOffersDto>>, GetOffersQuery>("offers.getOffers", offersQuery, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{offerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobOffer))]
        public async Task<ActionResult> GetJobOffer([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var query = new GetOfferQuery
            {
                OfferId = offerId
            };
            var response = await busClient.SendRequest<ResponseWrapper<JobOffer>, GetOfferQuery>("offers.getOffer", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{offerId}/applications")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetApplicationDto>))]
        public async Task<ActionResult> GetJobApplications([FromRoute] Guid offerId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting job applications for {Offer}", offerId);

            var query = new GetOfferApplicationsQuery(paginatedQuery.Page, paginatedQuery.PageSize)
            {
                OfferId = offerId,
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetApplicationDto>>, GetOfferApplicationsQuery>("applications.getOfferApplications", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{offerId}/reviews")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<Review>))]
        public async Task<ActionResult> GetReviews([FromRoute] Guid offerId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting page {Page} with page size: {PageSize} reviews for recruiter {Id}", paginatedQuery.Page, paginatedQuery.PageSize, offerId);

            var query = new GetRecruiterReviewsQuery
            {
                PageSize = paginatedQuery.PageSize,
                Page = paginatedQuery.Page,
                RecruiterId = offerId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<Review>>, GetRecruiterReviewsQuery>("reviews.getRecruiterReviews", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        [Route("{offerId}/reviews")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<ActionResult> SubmitReview([FromRoute] Guid offerId, [FromBody] Review review, CancellationToken cancellationToken)
        {
            var studentId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No userId claim specified");

            logger.LogInformation("Student {Student} reviews offer {Offer}", studentId, offerId);

            var command = new ReviewOfferCommand
            {
                StudentId = Guid.Parse(studentId),
                OfferId = offerId,
                Review = review
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, ReviewOfferCommand>("reviews.reviewOffer", command, cancellationToken);

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
