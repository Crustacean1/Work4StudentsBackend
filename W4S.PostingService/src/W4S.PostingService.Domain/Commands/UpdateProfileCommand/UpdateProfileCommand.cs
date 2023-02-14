using MediatR;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;

namespace W4S.PostingService.Domain.Commands
{
    public record UpdateProfileCommand : IRequest
    {
        public UserInfoUpdatedEvent ProfileEvent { get; set; }
    }
}
