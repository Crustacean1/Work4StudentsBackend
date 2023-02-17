using MediatR;
using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Models.Commands
{
    public record RegisterStudentCommand : IRequest
    {
        public StudentRegisteredEvent Student { get; set; }
    }
}
