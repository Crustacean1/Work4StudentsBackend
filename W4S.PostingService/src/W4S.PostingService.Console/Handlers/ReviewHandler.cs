using MediatR;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("reviews")]
    public class ReviewHandler : HandlerBase
    {
        private readonly ISender sender;

        public ReviewHandler(ILogger<ReviewHandler> logger, ISender sender) : base(logger)
        {
            this.sender = sender;
        }

        [BusRequestHandler("reviewApplication")]
        public async Task<ResponseWrapper<Guid>> OnReviewApplication(ReviewApplicationCommand command)
        {
            logger.LogInformation("Recrutier: {Recruiter} rates application: {Application}", command.RecruiterId, command.ApplicationId);

            return await ExecuteHandler(async () =>
            {
                Guid reviewId = await sender.Send(command);
                return (reviewId, 201);
            });
        }

        [BusRequestHandler("getRecruiterReviews")]
        public async Task<ResponseWrapper<PaginatedList<OfferReview>>> GetRecruiterReviews(GetRecruiterReviewsQuery query)
        {
            logger.LogInformation("Get reviews of recruiter {Recruiter}", query.RecruiterId);

            return await ExecuteHandler(async () =>
            {
                var reviews = await sender.Send(query);
                return (reviews, 200);
            });
        }

        [BusRequestHandler("reviewOffer")]
        public async Task<ResponseWrapper<Guid>> OnReviewOffer(ReviewOfferCommand command)
        {
            logger.LogInformation("Student: {Student} rates offer: {Offer}", command.StudentId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                Guid reviewId = await sender.Send(command);
                return (reviewId, 201);
            });
        }

        [BusRequestHandler("getStudentReviews")]
        public async Task<ResponseWrapper<PaginatedList<ApplicationReview>>> GetStudentReviews(GetStudentReviewsQuery query)
        {
            logger.LogInformation("Get reviews of student {Student}", query.StudentId);

            return await ExecuteHandler(async () =>
            {
                var reviews = await sender.Send(query);
                return (reviews, 200);
            });
        }
    }
}
