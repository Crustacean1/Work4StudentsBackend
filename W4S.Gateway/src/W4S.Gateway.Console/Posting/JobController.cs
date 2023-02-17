using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Models.Transfer;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Queries;

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
        [Authorize(Roles = "Employer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<string>))]
        public async Task<ActionResult> PostOffer([FromBody] PostOfferDto offer, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new PostOfferCommand { Offer = offer, RecruiterId = Guid.Parse(recruiterId) };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, PostOfferCommand>("offers.postOffer", command, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPost]
        [Route("{offerId}/close")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<string>))]
        public async Task<ActionResult> CloseOffer([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var recruiterId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No user id claim defined");

            var command = new CloseOfferCommand { OfferId = offerId, RecruiterId = Guid.Parse(recruiterId) };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, CloseOfferCommand>("offers.closeOffer", command, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "Employer")]
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

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("{offerId}")]
        public async Task<ActionResult> DeleteOffer([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var command = new DeleteOfferCommand
            {
                OfferId = offerId,
            };

            var response = await busClient.SendRequest<ResponseWrapper<Guid>, DeleteOfferCommand>("offers.deleteOffer", command, cancellationToken);
            return response.Messages.Any() ? StatusCode(400, new { ErrorMessage = response.Messages.FirstOrDefault() ?? "????" }) : StatusCode(204);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetOfferDto>))]
        public async Task<ActionResult> GetJobOffers([FromQuery] GetOffersQuery query, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetOfferDto>>, GetOffersQuery>("offers.getOffers", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{offerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOfferDetailsDto))]
        public async Task<ActionResult> GetJobOffer([FromRoute] Guid offerId, CancellationToken cancellationToken)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString();
            var query = new GetOfferQuery
            {
                OfferId = offerId,
                UserId = Guid.Parse(userId)
            };
            var response = await busClient.SendRequest<ResponseWrapper<GetOfferDetailsDto>, GetOfferQuery>("offers.getOffer", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize(Roles = "Employer,Administrator")]
        [Route("{offerId}/applications")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetApplicationDto>))]
        public async Task<ActionResult> GetJobApplications([FromRoute] Guid offerId, [FromQuery] PaginatedQuery paginatedQuery, CancellationToken cancellationToken)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("No userId claim specified");
            logger.LogInformation("Getting job applications for {Offer} {Tragedy}", offerId, busClient == null);

            var query = new GetOfferApplicationsQuery
            {
                Page = paginatedQuery.Page,
                PageSize = paginatedQuery.PageSize,
                OfferId = offerId,
                //asda = Guid.Parse(userId)
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<GetApplicationDto>>, GetOfferApplicationsQuery>("applications.getOfferApplications", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{offerId}/reviews")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<OfferReviewDto>))]
        public async Task<ActionResult> GetReviews([FromRoute] Guid offerId, [FromQuery] PaginatedQuery pagedQuery, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting page {Page} with page size: {PageSize} reviews for recruiter {Id}", pagedQuery.Page, pagedQuery.PageSize, offerId);

            var query = new GetOfferReviewsQuery
            {
                PageSize = pagedQuery.PageSize,
                Page = pagedQuery.Page,
                OfferId = offerId
            };

            var response = await busClient.SendRequest<ResponseWrapper<PaginatedList<OfferReviewDto>>, GetOfferReviewsQuery>("reviews.getOfferReviews", query, cancellationToken);
            return UnwrapResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        [Route("{offerId}/reviews")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<ActionResult> SubmitReview([FromRoute] Guid offerId, [FromBody] PostReviewDto review, CancellationToken cancellationToken)
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
                var aggregate = wrappedResponse.Messages.Aggregate("", (t, m) => (t + "\n" + m));
                return StatusCode(wrappedResponse.ResponseCode, new { ErrorMessages = wrappedResponse.Messages });
            }


            return StatusCode(wrappedResponse.ResponseCode, wrappedResponse.Response);
        }
    }
}
