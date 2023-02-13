using MediatR;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;

namespace W4S.PostingService.Domain.Commands
{
    public record RegisterRecruiterCommand : IRequest
    {
        public EmployerRegisteredEvent Recruiter { get; set; }
    }
}
