using MediatR;

namespace W4S.PostingService.Domain.Commands
{
    public record SubmitApplicationCommand : IRequest<Guid>
    {
        public Guid StudentId { get; set; }

        public Guid OfferId { get; set; }

        public SubmitApplicationDto Application { get; set; }
    }
}
