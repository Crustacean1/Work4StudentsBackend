using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewOfferCommandHandler : CommandHandlerBase, IRequestHandler<ReviewOfferCommand, Guid>
    {
        private readonly IReviewRepository<OfferReview> reviewRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IRepository<Application> applicationRepository;
        private readonly IMapper mapper;

        public ReviewOfferCommandHandler(IRepository<JobOffer> offerRepository, IRepository<Student> studentRepository, IReviewRepository<OfferReview> reviewRepository, IRepository<Application> applicationRepository)
        {
            this.offerRepository = offerRepository;
            this.studentRepository = studentRepository;
            this.reviewRepository = reviewRepository;

            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<OfferReviewDto, OfferReview>();
            });
            this.mapper = conf.CreateMapper();
            this.applicationRepository = applicationRepository;
        }

        public async Task<Guid> Handle(ReviewOfferCommand command, CancellationToken cancellationToken)
        {
            var offer = await GetEntity(offerRepository, command.OfferId);
            var student = await GetEntity(studentRepository, command.StudentId);

            var application = await applicationRepository.GetEntityAsync(a => a.OfferId == offer.Id && a.StudentId == student.Id);
            if (application is null)
            {
                throw new PostingException($"Could'nt post review, student {student.Id} did not apply for offer {offer.Id}", 400);
            }

            var previousReview = await reviewRepository.GetEntityAsync(r => r.AuthorId == student.Id && r.SubjectId == offer.Id);
            if (previousReview is not null)
            {
                throw new PostingException($"Student {student.Id} already rated offer {offer.Id}", 400);
            }

            var review = mapper.Map<OfferReview>(command.Review);
            review.Id = Guid.NewGuid();
            review.AuthorId = student.Id;
            review.SubjectId = offer.Id;
            review.CreationDate = DateTime.UtcNow;

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveAsync();

            return review.Id;
        }
    }
}
