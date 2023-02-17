using MediatR;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class DeleteOfferCommandHandler : CommandHandlerBase, IRequestHandler<DeleteOfferCommand, Guid>
    {
        private readonly IOfferRepository entityRepository;

        public DeleteOfferCommandHandler(IOfferRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task<Guid> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(entityRepository, request.OfferId);

            entityRepository.Delete(entity.Id);
            await entityRepository.SaveAsync();

            return entity.Id;
        }
    }
}
