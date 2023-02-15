using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Integrations;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewApplicationCommandHandler : CommandHandlerBase, IRequestHandler<ReviewApplicationCommand, Guid>
    {
        private readonly IReviewRepository<ApplicationReview> reviewRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IIntegrator integrator;
        private readonly IMapper mapper;

        public ReviewApplicationCommandHandler(IReviewRepository<ApplicationReview> reviewRepository, IApplicationRepository applicationRepository, IRepository<Recruiter> recruiterRepository, IOfferRepository offerRepository, IRepository<Student> studentRepository, IIntegrator integrator)
        {
            this.reviewRepository = reviewRepository;
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;

            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<ApplicationReviewDto, ApplicationReview>();
            });
            this.mapper = conf.CreateMapper();
            this.offerRepository = offerRepository;
            this.studentRepository = studentRepository;
            this.integrator = integrator;
        }

        public async Task<Guid> Handle(ReviewApplicationCommand request, CancellationToken cancellationToken)
        {
            var recruiter = await GetEntity(recruiterRepository, request.RecruiterId, "No recruiter with");
            var application = await GetEntity(applicationRepository, request.ApplicationId, "No application with");
            var offer = await GetEntity(offerRepository, application.OfferId, "No offer with");

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not post review, recruiter {recruiter.Id} does not own offer {offer.Id}", 400);
            }

            var prevReview = await reviewRepository.GetEntityAsync(r => r.AuthorId == recruiter.Id && r.SubjectId == application.Id);

            if (prevReview is not null)
            {
                throw new PostingException($"Recruiter {recruiter.Id} already rated application {application.Id} (offer: {prevReview.Id})", 400);
            }

            var review = mapper.Map<ApplicationReview>(request.Review);

            review.Id = Guid.NewGuid();
            review.AuthorId = recruiter.Id;
            review.SubjectId = application.Id;
            review.CreationDate = DateTime.UtcNow;

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveAsync();

            var student = await GetEntity(studentRepository, application.StudentId);
            await UpdateStudentRating(student);

            return review.Id;
        }

        public async Task UpdateStudentRating(Student student)
        {
            var newRating = await reviewRepository.GetRatingAverage(student.Id);
            student.Rating = newRating;
            await studentRepository.SaveAsync();
            integrator.OnStudentRatingUpdated(new UserRatingChangedEvent { UserId = student.Id, Rating = student.Rating });
        }
    }
}
