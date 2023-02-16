namespace W4S.PostingService.Domain.Dto
{
    public record ApplicationReviewDto
    {
        public decimal Rating { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public Guid ApplicationId { get; set; }

        public Guid RecruiterId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
