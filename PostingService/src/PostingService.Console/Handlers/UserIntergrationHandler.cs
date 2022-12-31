using PostingService.Console.Dto;
using ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [BusService("user")]
    public class UserIntegrationHandler
    {
        ILogger<UserIntegrationHandler> logger;

        public UserIntegrationHandler(ILogger<UserIntegrationHandler> logger)
        {
            this.logger = logger;
        }

        [BusEventHandler("created")]
        public void OnuserCreation(CreateUserDto userCreation)
        {
        }
    }
}
