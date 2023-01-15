using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("user")]
    public class UserIntegrationHandler
    {
        ILogger<UserIntegrationHandler> logger;

        public UserIntegrationHandler(ILogger<UserIntegrationHandler> logger)
        {
            this.logger = logger;
        }
    }
}
