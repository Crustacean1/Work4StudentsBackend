using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class DeleteReviewCommandHandler<T> : CommandHandlerBase, IRequestHandler<DeleteReviewCommand, Guid> where T : Review
    {
        private readonly IReviewRepository<T> entityRepository;

        public DeleteReviewCommandHandler(IReviewRepository<T> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task<Guid> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(entityRepository, request.ReviewId);

            entityRepository.Delete(entity.Id);
            await entityRepository.SaveAsync();

            return entity.Id;
        }
    }
}
