using AutoMapper;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;

namespace W4S.PostingService.Domain.Commands
{
    public class ReviewOfferCommandHandler
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<JobOffer> offerRepository;
        private readonly IMapper mapper;

        public ReviewOfferCommandHandler(IRepository<JobOffer> offerRepository, IRepository<Student> studentRepository, IRepository<Review> reviewRepository)
        {
            this.offerRepository = offerRepository;
            this.studentRepository = studentRepository;
            this.reviewRepository = reviewRepository;

            var conf = new MapperConfiguration(b =>
            {
                b.CreateMap<Review, Review>();
            });
            this.mapper = conf.CreateMapper();
        }

        public async Task<Guid> HandleCommand(ReviewOfferCommand command)
        {
            var offer = await offerRepository.GetEntityAsync(command.OfferId);
            if (offer is null)
            {
                throw new PostingException($"No offer with id: {command.OfferId}", 400);
            }

            var student = await studentRepository.GetEntityAsync(command.StudentId);
            if (student is null)
            {
                throw new PostingException($"No student with id: {command.StudentId}", 400);
            }

            var previousReview = await reviewRepository.GetEntityAsync(r => r.AuthorId == student.Id && r.SubjectId == offer.Id);
            if (previousReview is not null)
            {
                throw new PostingException($"Student {student.Id} already rated offer {offer.Id}", 400);
            }

            var review = mapper.Map<Review>(command.Review);
            review.Id = Guid.NewGuid();
            review.AuthorId = student.Id;
            review.SubjectId = offer.Id;

            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveAsync();

            return review.Id;
        }
    }
}
