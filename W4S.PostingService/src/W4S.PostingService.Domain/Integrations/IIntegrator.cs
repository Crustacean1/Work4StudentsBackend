using W4S.PostingService.Models.Events;

namespace W4S.PostingService.Domain.Integrations
{
    public interface IIntegrator
    {
        public void OnStudentRatingUpdated(UserRatingChangedEvent ratingEvent);

        public void OnRecruiterRatingUpdated(UserRatingChangedEvent ratingEvent);
    }
}
