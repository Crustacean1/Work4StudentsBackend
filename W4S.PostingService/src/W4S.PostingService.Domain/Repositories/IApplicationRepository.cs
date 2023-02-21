using System.Linq.Expressions;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Models.Queries;

namespace W4S.PostingService.Domain.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<PaginatedRecords<Application>> GetStudentApplications(Guid studentId, PaginatedQuery query);

        Task<PaginatedRecords<Application>> GetOfferApplications(Guid offerId, PaginatedQuery query);

        Task<IEnumerable<Application>> GetApplicationsWithEntities(Expression<Func<Application, bool>> selector);
    }
}
