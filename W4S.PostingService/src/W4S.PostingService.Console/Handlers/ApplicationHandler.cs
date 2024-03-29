using MediatR;
using W4S.PostingService.Models.Commands;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("applications")]
    public class ApplicationHandler : HandlerBase
    {

        public ApplicationHandler(ILogger<ApplicationHandler> logger, ISender sender) : base(sender, logger)
        {
        }

        [BusRequestHandler("submitApplication")]
        public async Task<ResponseWrapper<Guid>> OnSubmitApplication(SubmitApplicationCommand command)
        {
            logger.LogInformation("Applicant {Applicant} applies for {JobOffer} offer", command.StudentId, command.OfferId);

            return await ExecuteHandler(command, 201);
        }

        [BusRequestHandler("withdrawApplication")]
        public async Task<ResponseWrapper<Guid>> OnWithdrawApplication(WithdrawApplicationCommand command)
        {
            logger.LogInformation("Applicant {Applicant} withdraws application {Application}", command.StudentId, command.ApplicationId);

            return await ExecuteHandler(command, 200);
        }

        [BusRequestHandler("acceptApplication")]
        public async Task<ResponseWrapper<Guid>> OnAcceptApplication(AcceptApplicationCommand command)
        {
            logger.LogInformation("Recruiter {Recruiter} accepts application {Application}", command.RecruiterId, command.ApplicationId);

            return await ExecuteHandler(command, 200);
        }

        [BusRequestHandler("rejectApplication")]
        public async Task<ResponseWrapper<Guid>> OnRejectApplication(RejectApplicationCommand command)
        {
            logger.LogInformation("Recruiter {Recruiter} accepts application {Application}", command.RecruiterId, command.ApplicationId);

            return await ExecuteHandler(command, 200);
        }

        [BusRequestHandler("getOfferApplications")]
        public async Task<ResponseWrapper<PaginatedList<GetApplicationDto>>> OnGetOfferApplications(GetOfferApplicationsQuery query)
        {
            logger.LogInformation("Listing applications for offer {Offer}", query.OfferId);

            return await ExecuteHandler(query, 200);
        }

        [BusRequestHandler("getStudentApplications")]
        public async Task<ResponseWrapper<PaginatedList<GetApplicationDto>>> OnGetStudentApplications(GetStudentApplicationsQuery query)
        {
            logger.LogInformation("Listing applications of student: {Student}", query.StudentId);

            return await ExecuteHandler(query, 200);
        }

        [BusRequestHandler("deleteApplication")]
        public async Task<ResponseWrapper<Guid>> DeleteApplication(DeleteApplicationCommand command)
        {
            logger.LogInformation("Deleting application {Application}", command.ApplicationId);

            return await ExecuteHandler(command, 200);
        }
    }
}
