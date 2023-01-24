using W4S.PostingService.Domain.Entities;

namespace W4S.PostingService.Domain.Responses
{
    public record ApplicationListResponse : ResponseBase
    {
        public List<Application> Applications { get; set; }
    }
}
