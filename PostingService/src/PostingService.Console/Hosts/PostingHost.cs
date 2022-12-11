using PostingService.Console.Models;
using ServiceBus.Abstractions;
using System;

namespace PostingService.Console.Hosts
{
    public class PostingHost : IHostedService
    {
        private readonly ILogger<PostingHost> logger;
        private readonly IClient sender;

        public PostingHost(ILogger<PostingHost> logger,
                           IClient sender)
        {
            this.logger = logger;
            this.sender = sender;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var test = new CreateUserDto { Name = "John", Surname = "Paul", Username = "ThePope" };

            UserResponseDto response = await sender.SendRequest<UserResponseDto, CreateUserDto>("posting.user-creation", test);
            logger.LogInformation("Received response: {Response}",response.NewName);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
