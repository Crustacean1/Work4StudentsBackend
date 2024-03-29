using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;
using W4S.PostingService.Models.Commands;

namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommandHandler : CommandHandlerBase, IRequestHandler<WithdrawApplicationCommand, Guid>
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IRepository<Student> studentRepository;

        public WithdrawApplicationCommandHandler(IApplicationRepository applicationRepository, IRepository<Student> studentApplication)
        {
            this.applicationRepository = applicationRepository;
            this.studentRepository = studentApplication;
        }

        public async Task<Guid> Handle(WithdrawApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await GetEntity(applicationRepository, request.ApplicationId, "No application with");
            var student = await GetEntity(studentRepository, request.StudentId, "No student with");

            if (application.StudentId != student.Id)
            {
                throw new PostingException($"Cannot withdraw application, student {student.Id} does not own application {application.Id}", 400);
            }
            if (application.Status != ApplicationStatus.Submitted)
            {
                throw new PostingException("Can only withdraw application with status 'Submitted'");
            }

            application.Status = ApplicationStatus.Withdrawn;
            await applicationRepository.SaveAsync();

            return application.Id;
        }
    }
}
