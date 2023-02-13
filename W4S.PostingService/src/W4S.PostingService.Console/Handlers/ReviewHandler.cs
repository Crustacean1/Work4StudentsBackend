using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("reviews")]
    public class ReviewHandler : HandlerBase
    {
        private readonly ReviewApplicationCommandHandler reviewApplicationCommandHandler;
        private readonly ReviewOfferCommandHandler reviewOfferCommandHandler;
        private readonly GetRecruiterReviewsQueryHandler getRecruiterReviewsQueryHandler;
        private readonly GetStudentsReviewsQueryHandler getStudentsReviewsQueryHandler;

        public ReviewHandler(ReviewApplicationCommandHandler reviewApplicationCommandHandler, ILogger<ReviewHandler> logger, ReviewOfferCommandHandler reviewOfferCommandHandler, GetRecruiterReviewsQueryHandler getRecruiterReviewsQueryHandler, GetStudentsReviewsQueryHandler getStudentsReviewsQueryHandler) : base(logger)
        {
            this.reviewApplicationCommandHandler = reviewApplicationCommandHandler;
            this.reviewOfferCommandHandler = reviewOfferCommandHandler;
            this.getRecruiterReviewsQueryHandler = getRecruiterReviewsQueryHandler;
            this.getStudentsReviewsQueryHandler = getStudentsReviewsQueryHandler;
        }

        [BusRequestHandler("reviewApplication")]
        public async Task<ResponseWrapper<Guid>> OnReviewApplication(ReviewApplicationCommand command)
        {
            logger.LogInformation("Recrutier: {Recruiter} rates application: {Application}", command.RecruiterId, command.ApplicationId);

            return await ExecuteHandler(async () =>
            {
                Guid reviewId = await reviewApplicationCommandHandler.HandleCommand(command);
                return (reviewId, 201);
            });
        }

        [BusRequestHandler("getRecruiterReviews")]
        public async Task<ResponseWrapper<PaginatedList<Review>>> GetRecruiterReviews(GetRecruiterReviewsQuery query)
        {
            logger.LogInformation("Get reviews of recruiter {Recruiter}", query.RecruiterId);

            return await ExecuteHandler(async () =>
            {
                var reviews = await getRecruiterReviewsQueryHandler.HandleQuery(query);
                return (reviews, 200);
            });
        }

        [BusRequestHandler("reviewOffer")]
        public async Task<ResponseWrapper<Guid>> OnReviewOffer(ReviewOfferCommand command)
        {
            logger.LogInformation("Student: {Student} rates offer: {Offer}", command.StudentId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                Guid reviewId = await reviewOfferCommandHandler.HandleCommand(command);
                return (reviewId, 201);
            });
        }

        [BusRequestHandler("getStudentReviews")]
        public async Task<ResponseWrapper<PaginatedList<Review>>> GetStudentReviews(GetStudentReviewsQuery query)
        {
            logger.LogInformation("Get reviews of student {Student}", query.StudentId);

            return await ExecuteHandler(async () =>
            {
                var reviews = await getStudentsReviewsQueryHandler.HandleQuery(query);
                return (reviews, 200);
            });
        }
    }
}
