using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Registration;
using W4S.ServiceBus.Attributes;

namespace W4S.PostingService.Console.Handlers
{
    [BusService("registered")]
    public class RegistrationIntegrationHandler
    {
        ILogger<RegistrationIntegrationHandler> logger;

        public RegistrationIntegrationHandler(ILogger<RegistrationIntegrationHandler> logger)
        {
            this.logger = logger;
        }

        [BusEventHandler("student")]
        public void OnStudentRegistration(StudentRegisteredEvent registrationEvent)
        {
            logger.LogInformation("Adding new applicant (student) with id: {Id}", registrationEvent.Id);
        }
    }
}
