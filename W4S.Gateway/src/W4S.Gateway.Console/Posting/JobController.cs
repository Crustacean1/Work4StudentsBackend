using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Responses;

namespace W4S.Gateway.Console.Posting
{
    [ApiController]
    [Route("api/joboffer")]
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
            var response = await busClient.SendRequest<JobOfferCreatedDto, PostJobOfferCommand>("offer.create", postJobOffer, cancellationToken);
            if (response.Errors.Any())
            {
                return StatusCode(500, response.Errors);
            }
            return Ok(response.Id);
        }
    }
}
