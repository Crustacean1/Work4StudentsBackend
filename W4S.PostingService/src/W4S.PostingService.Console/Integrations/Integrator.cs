using W4S.PostingService.Domain.Commands;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Integrations;
using W4S.ServiceBus.Abstractions;

namespace W4S.PostingService.Console.Integrators
{
    public class Integrator : IIntegrator
    {
        private readonly IClient busClient;

        public Integrator(IClient client)
        {
            this.busClient = client;
        }

        public void OnStudentRatingUpdated(UserRatingChangedEvent ratingEvent)
        {
            busClient.SendEvent<UserRatingChangedEvent>("profiles.update.student.rating", ratingEvent);
        }

        public void OnRecruiterRatingUpdated(UserRatingChangedEvent ratingEvent)
        {
            busClient.SendEvent<UserRatingChangedEvent>("profiles.update.employer.rating", ratingEvent);
        }
    }
}
