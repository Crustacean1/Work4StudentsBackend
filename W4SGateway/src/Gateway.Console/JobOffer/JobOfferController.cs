using System;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Abstractions;

namespace Gateway.Console.Controllers
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
        public async Task<ActionResult<Guid>> CreateJobOffer([FromBody] CreateJobOfferDto jobOffer, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request: Create job posting");
            var response = await busClient.SendRequest<CreateJobOfferResponse, CreateJobOfferDto>("posting.createOffer", jobOffer, cancellationToken);
            return response.Id;
        }
    }
}
