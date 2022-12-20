using Microsoft.AspNetCore.Mvc;
using ServiceBus.Abstractions;

namespace Gateway.Console.Microservices.JobOffer
{
    [Route("joboffers")]
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
        public async Task<ActionResult> CreateJobOffer([FromBody] CreateJobOfferDto jobOffer, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Create job posting");
            CreateJobOfferResponse response =
                await busClient.SendRequest<CreateJobOfferResponse, CreateJobOfferDto>("offers.create", jobOffer, cancellationToken);
            logger.LogInformation("Received response");
            return Ok(response.Id);
        }
    }
}
