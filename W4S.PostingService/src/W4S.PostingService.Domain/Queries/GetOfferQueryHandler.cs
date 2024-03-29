using MediatR;
using Microsoft.Extensions.Logging;
using W4S.PostingService.Domain.Entities;
using W4S.PostingService.Domain.Exceptions;
using W4S.PostingService.Domain.Repositories;
using W4S.PostingService.Models.Queries;
using W4S.PostingService.Models.Transfer;

namespace W4S.PostingService.Domain.Queries
{
    public class GetOfferQueryHandler : IRequestHandler<GetOfferQuery, GetOfferDetailsDto>
    {
        private ILogger<GetOfferQueryHandler> logger;
        private readonly IOfferRepository offerRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Recruiter> recruiterRepository;

        public GetOfferQueryHandler(IOfferRepository offerRepository, IRepository<Recruiter> recruiterRepository, IRepository<Student> studentRepository, ILogger<GetOfferQueryHandler> logger)
        {
            this.offerRepository = offerRepository;
            this.recruiterRepository = recruiterRepository;
            this.studentRepository = studentRepository;
            this.logger = logger;
        }

        public async Task<GetOfferDetailsDto> Handle(GetOfferQuery query, CancellationToken cancellationToken)
        {
            var personId = await GetPerson(query.UserId);
            var offer = await offerRepository.GetOfferDetails(query.OfferId, personId);


            if (offer is null)
            {
                throw new PostingException($"No job offer with id: {query.OfferId}");
            }

            logger.LogInformation("For student {Student} (un)real: {Fake} applied: {Applied}", query.UserId, query.OfferId, offer.Applied);

            return offer;
        }

        private async Task<Guid> GetPerson(Guid userId)
        {
            Person? person = await studentRepository.GetEntityAsync(s => s.Id == userId);
            if (person is null)
            {
                person = await recruiterRepository.GetEntityAsync(s => s.Id == userId);
            }
            return person?.Id ?? Guid.Empty;
        }
    }
}
