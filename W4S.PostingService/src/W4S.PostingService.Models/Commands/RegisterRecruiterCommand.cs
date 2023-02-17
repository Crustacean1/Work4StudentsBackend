using MediatR;
using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Models.Commands
{
    public record RegisterRecruiterCommand : IRequest
    {
        public EmployerRegisteredEvent Recruiter { get; set; }
    }
}
