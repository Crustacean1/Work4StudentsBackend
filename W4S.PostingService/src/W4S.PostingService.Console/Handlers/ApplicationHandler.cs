using MediatR;
using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Queries;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("applications")]
    public class ApplicationHandler : HandlerBase
    {
        private readonly ISender sender;

        public ApplicationHandler(ILogger<ApplicationHandler> logger, ISender sender) : base(logger)
        {
            this.sender = sender;
        }

        [BusRequestHandler("submitApplication")]
        public async Task<ResponseWrapper<Guid>> OnSubmitApplication(SubmitApplicationCommand command)
        {
            logger.LogInformation("Applicant {Applicant} applies for {JobOffer} offer", command.StudentId, command.OfferId);

            return await ExecuteHandler(async () =>
            {
                var applicationId = await sender.Send(command);
                return (applicationId, 201);
            });
        }

        [BusRequestHandler("withdrawApplication")]
        public async Task<ResponseWrapper<Guid>> OnWithdrawApplication(WithdrawApplicationCommand command)
        {
            logger.LogInformation("Applicant {Applicant} withdraws application {Application}", command.StudentId, command.ApplicationId);

            return await ExecuteHandler(async () =>
            {
                var applicationId = await sender.Send(command);
                return (applicationId, 201);
            });
        }

        public async Task<ResponseWrapper<Guid>> OnAcceptApplication(AcceptApplicationCommand command)
        {
            logger.LogInformation("Recruiter {Recruiter} accepts application {Application}", command.RecruiterId, command.ApplicationId);

            return await ExecuteHandler(async () =>
            {
                var applicationId = await sender.Send(command);
                return (applicationId, 201);
            });
        }

        [BusRequestHandler("getOfferApplications")]
        public async Task<ResponseWrapper<PaginatedList<GetApplicationDto>>> OnGetOfferApplications(GetOfferApplicationsQuery query)
        {
            logger.LogInformation("Listing applications for offer {Offer}", query.OfferId);

            return await ExecuteHandler(async () =>
            {
                var response = await sender.Send(query);
                return (response, 200);
            });
        }

        [BusRequestHandler("getStudentApplications")]
        public async Task<ResponseWrapper<PaginatedList<GetApplicationDto>>> OnGetStudentApplications(GetStudentApplicationsQuery query)
        {
            logger.LogInformation("Lising applications of student: {Student}", query.StudentId);

            return await ExecuteHandler(async () =>
            {
                var response = await sender.Send(query);
                return (response, 200);
            });
        }
    }
}
