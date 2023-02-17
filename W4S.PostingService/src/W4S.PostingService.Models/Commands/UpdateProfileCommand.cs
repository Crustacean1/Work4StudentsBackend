using MediatR;
using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Models.Commands
{
    public record UpdateProfileCommand : IRequest
    {
        public UserChangedEvent ProfileEvent { get; set; }
    }
}
