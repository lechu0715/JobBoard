using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Queries
{

    public class GetJobOfferByIdQueryHandler : IRequestHandler<GetJobOfferByIdQuery, ErrorOr<JobOffer>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public GetJobOfferByIdQueryHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<JobOffer>> Handle(GetJobOfferByIdQuery query, CancellationToken cancellationToken)
        {
            var jobOffer = await _jobOfferRepository.GetJobOfferById(query.Id);

            //if (jobOffer != null)
            //{
                return jobOffer;
            //}
        }
    }
}
