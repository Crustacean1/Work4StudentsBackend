using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Queries
{
    public class GetStudentsReviewsQueryHandler : IRequestHandler<GetStudentReviewsQuery, PaginatedList<ApplicationReviewDto>>
    {
        private readonly IReviewRepository<ApplicationReview> reviewRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public GetStudentsReviewsQueryHandler(IReviewRepository<ApplicationReview> reviewRepository, IRepository<Student> studentRepository)
        {
            this.reviewRepository = reviewRepository;
            this.studentRepository = studentRepository;
            var mapperConf = new MapperConfiguration(b =>
            {
                b.CreateMap<ApplicationReview, ApplicationReviewDto>();
            });
            this.mapper = mapperConf.CreateMapper();
        }

        public async Task<PaginatedList<ApplicationReviewDto>> Handle(GetStudentReviewsQuery query, CancellationToken cancellationToken)
        {
            var student = await studentRepository.GetEntityAsync(query.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {query.StudentId}", 400);
            }
            var reviews = await reviewRepository.GetReceivedReviews(student.Id, query);

            return new PaginatedList<ApplicationReviewDto>(reviews.Items.Select(mapper.Map<ApplicationReviewDto>).ToList(), query.Page, query.PageSize, reviews.TotalCount);
        }
    }
}
