using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class DeleteReviewCommandHandler<T> : CommandHandlerBase, IRequestHandler<DeleteApplicationCommand, Guid> where T : Review
    {
        private readonly IReviewRepository<T> entityRepository;

        public DeleteReviewCommandHandler(IReviewRepository<T> entityRepository)
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
