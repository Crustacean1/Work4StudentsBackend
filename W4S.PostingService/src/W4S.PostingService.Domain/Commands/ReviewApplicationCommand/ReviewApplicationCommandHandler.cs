using AutoMapper;
using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewApplicationCommandHandler : CommandHandlerBase, IRequestHandler<ReviewApplicationCommand, Guid>
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IMapper mapper;

        public ReviewApplicationCommandHandler(IRepository<Review> reviewRepository, IRepository<Application> applicationRepository, IRepository<Recruiter> recruiterRepository, IRepository<JobOffer> offerRepository)
        {
            this.reviewRepository = reviewRepository;
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;
            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<Review, Review>();
            });
            this.mapper = conf.CreateMapper();
            this.offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(ReviewApplicationCommand command, CancellationToken cancellationToken)
        {
            var recruiter = await GetEntity(recruiterRepository, command.RecruiterId);

            var application = await GetEntity(applicationRepository, command.ApplicationId);
            var offer = await GetEntity(offerRepository, application.OfferId);

            if (offer.RecruiterId != recruiter.Id)
            {
                throw new PostingException($"Could not post review, recruiter {recruiter.Id} does not own offer {offer.Id}", 400);
            }

            var prevReview = await reviewRepository.GetEntityAsync(r => r.AuthorId == recruiter.Id && r.SubjectId == application.Id);

            if (prevReview is not null)
            {
                throw new PostingException($"Recruiter {recruiter.Id} already rated application {application.Id} (offer: {prevReview.Id})", 400);
            }

            var review = mapper.Map<Review>(command.Review);

            review.Id = Guid.NewGuid();
            review.AuthorId = recruiter.Id;
            review.SubjectId = application.Id;

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveAsync();

            return review.Id;
        }
    }
}
