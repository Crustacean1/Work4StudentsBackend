using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W4S.ServiceBus.Abstractions;

namespace Gateway.Console.Microservices.JobOffer
{
    [Route("joboffers")]
    [Authorize]
    public class JobOfferController : ControllerBase
    {
        private readonly ILogger<JobOfferController> logger;
        private readonly IClient busClient;

        public JobOfferController(ILogger<JobOfferController> logger, IClient busClient)
        {
            this.logger = logger;
            this.busClient = busClient;
        }

        [HttpPut]
        [Authorize(Roles = "Employer,Administrator")]
        public async Task<ActionResult> CreateJobOffer([FromBody] CreateJobOfferDto jobOffer, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Create job posting");
            CreateJobOfferResponse response =
                await busClient.SendRequest<CreateJobOfferResponse, CreateJobOfferDto>("offer.create", jobOffer, cancellationToken);
            logger.LogInformation("Received response");
            return Ok(response.Id);
        }
    }
}
