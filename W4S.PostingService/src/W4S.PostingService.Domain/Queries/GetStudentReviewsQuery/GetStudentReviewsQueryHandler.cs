using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentsReviewsQueryHandler : IRequestHandler<GetStudentReviewsQuery, PaginatedList<Review>>
    {
        private readonly IReviewRepository<ApplicationReview> reviewRepository;
        private readonly IRepository<Student> studentRepository;

        public GetStudentsReviewsQueryHandler(IReviewRepository<ApplicationReview> reviewRepository, IRepository<Student> studentRepository)
        {
            this.reviewRepository = reviewRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<PaginatedList<Review>> Handle(GetStudentReviewsQuery query, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(query.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {query.StudentId}", 400);
            }
            var reviews = await reviewRepository.GetReceivedReviews(student.Id, query);

            return new PaginatedList<Review>(reviews.Items.ToList(), query.Page, query.PageSize, reviews.TotalCount);
        }
    }
}
