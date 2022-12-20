using ServiceBus.Attributes;
using PostingService.Console.Models;

namespace PostingService.Console.Handlers
{
    [ServiceBusHandler("offers")]
    public class JobOfferHandler
    {
        ILogger<JobOfferHandler> logger;

        public JobOfferHandler(ILogger<JobOfferHandler> logger)
        {
            this.logger = logger;
        }

        [ServiceBusMethod("create")]
        public JobOfferCreatedDto OnCreateJobOffer(CreateJobOfferDto offer)
        {
            return new JobOfferCreatedDto { Id = Guid.Empty };
        }
    }

    public class JobOfferCreatedDto
    {
        public Guid Id { get; set; }
    }
}
