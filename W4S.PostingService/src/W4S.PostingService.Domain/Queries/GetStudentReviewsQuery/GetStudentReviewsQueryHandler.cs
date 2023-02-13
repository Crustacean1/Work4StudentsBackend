using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentsReviewsQueryHandler : IRequestHandler<GetStudentReviewsQuery, PaginatedList<ApplicationReview>>
    {
        private readonly IReviewRepository<ApplicationReview> reviewRepository;
        private readonly IRepository<Student> studentRepository;

        public GetStudentsReviewsQueryHandler(IReviewRepository<ApplicationReview> reviewRepository, IRepository<Student> studentRepository)
        {
            this.reviewRepository = reviewRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<PaginatedList<ApplicationReview>> Handle(GetStudentReviewsQuery query, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(query.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {query.StudentId}", 400);
            }
            var reviews = await reviewRepository.GetStudentReviews(student.Id, query.Page, query.PageSize);
            var reviewCount = await reviewRepository.GetStudentReviewCount(student.Id);

            return new PaginatedList<ApplicationReview>(reviews.ToList(), query.Page, query.PageSize, reviewCount);
        }
    }
}
