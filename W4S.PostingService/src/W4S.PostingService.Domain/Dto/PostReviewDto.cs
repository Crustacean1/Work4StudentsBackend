namespace W4S.PostingService.Domain.Dto
{
    public record PostReviewDto
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
