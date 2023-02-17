using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Dto;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Integrations;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewOfferCommandHandler : CommandHandlerBase, IRequestHandler<ReviewOfferCommand, Guid>
    {
        private readonly IReviewRepository<OfferReview> reviewRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly IIntegrator integrator;
        private readonly IMapper mapper;

        public ReviewOfferCommandHandler(IOfferRepository offerRepository, IRepository<Student> studentRepository, IReviewRepository<OfferReview> reviewRepository, IApplicationRepository applicationRepository, IRepository<Recruiter> recruiterRepository, IIntegrator integrator)
        {
            this.offerRepository = offerRepository;
            this.studentRepository = studentRepository;
            this.reviewRepository = reviewRepository;

            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<PostReviewDto, OfferReview>();
            });
            this.mapper = conf.CreateMapper();
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;
            this.integrator = integrator;
        }

        public async Task<Guid> Handle(ReviewOfferCommand command, CancellationToken cancellationToken)
        {
            var offer = await GetEntity(offerRepository, command.OfferId, "No offer with");
            var student = await GetEntity(studentRepository, command.StudentId, "No student with");

            var application = await applicationRepository.GetEntityAsync(a => a.OfferId == offer.Id && a.StudentId == student.Id);
            if (application is null)
            {
                throw new PostingException($"Couldn't post review, student {student.Id} did not apply for offer {offer.Id}", 400);
            }

            var previousReview = await reviewRepository.GetEntityAsync(r => r.StudentId == student.Id && r.OfferId == offer.Id);
            if (previousReview is not null)
            {
                throw new PostingException($"Student {student.Id} already rated offer {offer.Id}", 400);
            }

            var review = mapper.Map<OfferReview>(command.Review);
            review.Id = Guid.NewGuid();
            review.StudentId = student.Id;
            review.OfferId = offer.Id;
            review.CreationDate = DateTime.UtcNow;

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveAsync();

            var recruiter = await GetEntity(recruiterRepository, offer.RecruiterId, "No recruiter to update with");
            await UpdateRecruiterRating(recruiter);

            return review.Id;
        }

        public async Task UpdateRecruiterRating(Recruiter recruiter)
        {
            var newRating = await reviewRepository.GetRatingAverage(recruiter.Id);
            recruiter.Rating = newRating;
            await recruiterRepository.SaveAsync();
            integrator.OnRecruiterRatingUpdated(new UserRatingChangedEvent { UserId = recruiter.Id, Rating = recruiter.Rating });
        }
    }
}
