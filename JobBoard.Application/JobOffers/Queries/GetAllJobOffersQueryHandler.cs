using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Queries
{

    public class GetAllJobOffersQueryHandler : IRequestHandler<GetAllJobOffersQuery, ErrorOr<List<JobOffer>>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public GetAllJobOffersQueryHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<List<JobOffer>>> Handle(GetAllJobOffersQuery query, CancellationToken cancellationToken)
        {
            return await _jobOfferRepository.GetAllJobOffers();
        }
    }
}
