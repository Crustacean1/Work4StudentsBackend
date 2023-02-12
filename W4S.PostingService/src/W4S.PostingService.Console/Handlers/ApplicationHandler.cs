using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("applications")]
    public class ApplicationHandler : HandlerBase
    {
        private readonly SubmitApplicationCommandHandler submitApplicationCommandHandler;
        private readonly GetOfferApplicationsQueryHandler getOfferApplicationsQueryHandler;
        private readonly GetStudentApplicationsQueryHandler getStudentApplicationQueryHandler;

        public ApplicationHandler(ILogger<ApplicationHandler> logger, SubmitApplicationCommandHandler submitApplicationCommandHandler, GetOfferApplicationsQueryHandler getOfferApplicationsQueryHandler, GetStudentApplicationsQueryHandler getStudentApplicationQueryHandler) : base(logger)
        {
            this.submitApplicationCommandHandler = submitApplicationCommandHandler;
            this.getOfferApplicationsQueryHandler = getOfferApplicationsQueryHandler;
            this.getStudentApplicationQueryHandler = getStudentApplicationQueryHandler;
        }

        [BusRequestHandler("submitApplication")]
        public async Task<ResponseWrapper<Guid>> OnSubmitApplication(SubmitApplicationCommand command)
        {
            logger.LogInformation("Applicant {Applicant} applies for {JobOffer} offer", command.StudentId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                var applicationId = await submitApplicationCommandHandler.HandleCommand(command);
                return (applicationId, 201);
            });
        }

        [BusRequestHandler("getOfferApplications")]
        public async Task<ResponseWrapper<PaginatedList<Application>>> OnGetOfferApplications(GetOfferApplicationsQuery query)
        {
            logger.LogInformation("Lising applications for offer {Offer}", query.OfferId);

            return await ExecuteHandler(async () =>
            {
                var response = await getOfferApplicationsQueryHandler.HandleQuery(query);
                return (response, 200);
            });
        }

        [BusRequestHandler("getStudentApplications")]
        public async Task<ResponseWrapper<PaginatedList<Application>>> OnGetStudentApplications(GetStudentApplicationsQuery query)
        {
            logger.LogInformation("Lising applications of student: {Student}", query.StudentId);

            return await ExecuteHandler(async () =>
            {
                var response = await getStudentApplicationQueryHandler.HandleQuery(query);
                return (response, 200);
            });
        }
    }
}
