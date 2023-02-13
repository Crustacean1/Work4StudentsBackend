using MediatR;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Domain.ValueType;

namespace W4S.PostingService.Domain.Commands
{
    public class WithdrawApplicationCommandHandler : CommandHandlerBase, IRequestHandler<WithdrawApplicationCommand, Unit>
    {
        private readonly IRepository<Application> applicationRepository;
        private readonly IRepository<Student> studentRepository;

        public WithdrawApplicationCommandHandler(IRepository<Application> applicationRepository, IRepository<Student> studentApplication)
        {
            this.applicationRepository = applicationRepository;
            this.studentRepository = studentApplication;
        }

        public async Task<Unit> Handle(WithdrawApplicationCommand command, CancellationToken cancellationToken)
        {
            var application = await GetEntity(applicationRepository, command.ApplicationId);
            var student = await GetEntity(studentRepository, command.StudentId);

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

            return Unit.Value;
        }
    }
}
