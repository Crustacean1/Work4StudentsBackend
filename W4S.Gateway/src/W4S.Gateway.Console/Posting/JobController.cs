using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Responses;
using W4S.PostingService.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        public async Task<ActionResult> PostJobOffer([FromBody] PostJobOfferCommand postJobOffer, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<JobOfferCreatedDto, PostJobOfferCommand>("offer.post", postJobOffer, cancellationToken);

            if (response.Errors.Any())
            {
                return StatusCode(400, response.Errors);
            }
            return Ok(response.Id);
        }

        [HttpGet]
        public async Task<ActionResult> GetOffers([FromQuery] int page, int pageSize, CancellationToken cancellationToken)
        {
            var response = await busClient.SendRequest<JobOffersDto, JobOffersQuery>("offer.list", new JobOffersQuery { Page = page, PageSize = pageSize }, cancellationToken);

            return Ok(response.JobOffers);
        }

        /*[HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> GetOffer([FromRoute] Guid id, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        [Route("apply/{id}")]
        public async Task<ActionResult> ApplyForOffer([FromRoute] Guid id)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //await busClient.SendRequest<ApplicationSubmittedDto, SubmitApplicationDto>("offer.apply", new SubmitApplicationDto { });
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<ActionResult> UpdateOffer([FromRoute] Guid id)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //await busClient.SendRequest < ApplicationUpdatedDto, 
            return Ok();
        }*/
    }
}
