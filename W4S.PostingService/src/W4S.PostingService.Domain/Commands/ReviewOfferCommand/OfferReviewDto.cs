using System.ComponentModel.DataAnnotations;

namespace W4S.PostingService.Domain.Entities
{
    public class OfferReviewDto : Entity
    {
        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
