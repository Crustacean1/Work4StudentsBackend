using PostingService.Console.Models;
using ServiceBus.Attributes;

namespace PostingService.Console.Handlers
{
    [ServiceBusHandler("posting")]
    public class UserCreationHandler
    {
        private readonly ILogger<UserCreationHandler> logger;

        public UserCreationHandler(ILogger<UserCreationHandler> logger)
        {
            this.logger = logger;
        }

        [ServiceBusMethod("user-creation")]
        public UserResponseDto OnCreateUser(CreateUserDto userCreationDto)
        {
            return new UserResponseDto { NewName = $"{userCreationDto.Name} {userCreationDto.Surname}" };
        }
    }
}
