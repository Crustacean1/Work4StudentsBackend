using ServiceBus.Attributes;
using PostingService.Console.Models;

namespace PostingService.Console.Handlers
{
    [ServiceBusHandler("jobOffer")]
    public class JobOfferHandler
    {
        public void OnCreateJobOffer(CreateJobOfferDto offer)
        {

        }
    }
}
