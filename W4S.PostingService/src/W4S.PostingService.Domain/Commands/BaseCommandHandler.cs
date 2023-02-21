using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class CommandHandlerBase
    {
        protected async Task<T> GetEntity<T>(IRepository<T> repository, Guid id, string errorMsg = "No entity with id: ")
        {
            var entity = await repository.GetEntityAsync(id);
            if (entity is null)
            {
                throw new PostingException($"{errorMsg} Id: {id}");
            }
            return entity;
        }
    }
}
