using AutoMapper;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewApplicationCommandHandler
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Recruiter> recruiterRepository;
        private readonly IMapper mapper;

        public ReviewApplicationCommandHandler(IRepository<Review> reviewRepository, IRepository<Application> applicationRepository, IRepository<Recruiter> recruiterRepository)
        {
            this.reviewRepository = reviewRepository;
            this.applicationRepository = applicationRepository;
            this.recruiterRepository = recruiterRepository;
            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<Review, Review>();
            });
            this.mapper = conf.CreateMapper();
        }

        public async Task<Guid> HandleCommand(ReviewApplicationCommand command)
        {
            var recruiter = await recruiterRepository.GetEntityAsync(command.RecruiterId);
            if (recruiter is null)
            {
                throw new PostingException($"No recruiter with id: {command.RecruiterId}", 400);
            }

            var application = await applicationRepository.GetEntityAsync(command.ApplicationId);
            if (application is null)
            {
                throw new PostingException($"No application with id: {command.ApplicationId}", 400);
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
