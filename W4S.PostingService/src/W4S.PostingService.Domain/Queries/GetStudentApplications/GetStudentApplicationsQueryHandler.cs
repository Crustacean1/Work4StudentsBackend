using System.Linq.Expressions;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentApplicationsQueryHandler : IRequestHandler<GetStudentApplicationsQuery, PaginatedList<Application>>
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Student> studentRepository;

        public GetStudentApplicationsQueryHandler(IRepository<Student> studentRepository, IRepository<Application> applicationRepository)
        {
            this.studentRepository = studentRepository;
            this.applicationRepository = applicationRepository;
        }

        public async Task<PaginatedList<Application>> Handle(GetStudentApplicationsQuery query, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(query.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {query.StudentId}");
            }

            Expression<Func<Application, bool>> selector = (Application a) => a.StudentId == student.Id;

            var applications = await applicationRepository.GetEntitiesAsync(query.Page, query.PageSize, selector, a => a.LastChanged);
            var totalCount = await applicationRepository.GetTotalCount(selector);

            return new PaginatedList<Application>(applications.ToList(), query.Page, query.PageSize, totalCount);
        }
    }
}
