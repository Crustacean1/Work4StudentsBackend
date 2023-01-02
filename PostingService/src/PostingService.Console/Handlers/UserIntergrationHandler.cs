using PostingService.Console.Dto;
using W4S.ServiceBus.Attributes;

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
        public void OnUserCreation(CreateUserDto userCreation)
        {
            logger.LogInformation("User has been created: {Name}", userCreation.Name);
            return;
        }
    }
}
