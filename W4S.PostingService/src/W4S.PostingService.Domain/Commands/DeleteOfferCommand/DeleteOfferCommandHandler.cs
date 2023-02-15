using MediatR;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class DeleteOfferCommandHandler : CommandHandlerBase, IRequestHandler<DeleteApplicationCommand, Guid>
    {
        private readonly IOfferRepository entityRepository;

        public DeleteOfferCommandHandler(IOfferRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task<Guid> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(entityRepository, request.ApplicationId);

            await entityRepository.DeleteAsync(entity.Id);

            return entity.Id;
        }
    }
}
