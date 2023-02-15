using MediatR;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class DeleteApplicationCommandHandler : CommandHandlerBase, IRequestHandler<DeleteApplicationCommand, Guid>
    {
        private readonly IApplicationRepository applicationRepository;

        public DeleteApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public async Task<Guid> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await GetEntity(applicationRepository, request.ApplicationId);

            await applicationRepository.DeleteAsync(application.Id);

            return application.Id;
        }
    }
}
