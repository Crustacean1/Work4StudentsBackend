using MediatR;
using W4S.PostingService.Domain.Dto;

namespace W4S.PostingService.Models.Commands
{
    public record ReviewApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }

        public Guid RecruiterId { get; set; }

        public PostReviewDto Review { get; set; }
    }
}
