using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Responses;
using W4S.PostingService.Domain.Queries;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {

        private readonly ILogger<JobController> logger;
        private readonly IClient busClient;

        public ApplicationController(ILogger<JobController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPost]
        [Route("apply")]
        public async Task<ActionResult> SubmitApplication([FromBody] ApplyForJobCommand applicationCommand, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<ApplicationSubmittedDto, ApplyForJobCommand>("application.apply", applicationCommand, cancellationToken);

            if (response.Errors.Any())
            {
                return StatusCode(400, response.Errors);
            }

            return Ok(response.Id);
        }

        [HttpPost]
        [Route("accept")]
        public async Task<ActionResult> AcceptApplication([FromBody] AcceptApplicationDto acceptCommand, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<ApplicationAcceptedDto, AcceptApplicationDto>("application.accept", acceptCommand, cancellationToken);
            if (response.Errors.Any())
            {
                return StatusCode(400, response.Errors);
            }
            return Ok();
        }

        [HttpGet]
        [Route("/offer/{id}")]
        public async Task<ActionResult> GetJobApplications([FromRoute] Guid id, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new ListOfferApplicationsQuery
            {
                Page = page,
                PageSize = pageSize,
                OfferId = id
            };

            var response = await busClient.SendRequest<ApplicationListResponse, ListOfferApplicationsQuery>("offer.list", query, cancellationToken);

            if (response.Errors.Any())
            {
                return StatusCode(400, response.Errors);
            }

            return Ok(response.Applications);
        }

        [HttpGet]
        [Route("/applicant/{id}")]
        public async Task<ActionResult> GetApplicantApplications([FromRoute] Guid id, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new ListApplicantApplicationsQuery
            {
                Page = page,
                PageSize = pageSize,
                ApplicantId = id
            };

            var response = await busClient.SendRequest<ApplicationListResponse, ListApplicantApplicationsQuery>("offer.list", query, cancellationToken);

            if (response.Errors.Any())
            {
                return StatusCode(400, response.Errors);
            }

            return Ok(response.Applications);
        }
    }
}
