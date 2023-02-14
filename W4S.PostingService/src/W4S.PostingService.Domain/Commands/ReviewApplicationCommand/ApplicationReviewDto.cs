namespace W4S.PostingService.Domain.Commands
{
    public class ApplicationReviewDto
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
