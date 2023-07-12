using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Application.Services.JobOffers;
using JobBoard.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Application.JobOffers.Queries
{

    public class GetJobOfferByIdQueryHandler : IRequestHandler<GetJobOfferByIdQuery, ErrorOr<JobOffer>>
    {
        private readonly IJobOfferQueryService _jobOfferQueryService;

        public GetJobOfferByIdQueryHandler(IJobOfferQueryService jobOfferQueryService)
        {
            _jobOfferQueryService = jobOfferQueryService;
        }

        public async Task<ErrorOr<JobOffer>> Handle(GetJobOfferByIdQuery query, CancellationToken cancellationToken)
        {
            var jobOffer = await _jobOfferQueryService.GetJobOfferById(query.Id);

            //if (jobOffer != null)
            //{
                return jobOffer;
            //}
        }
    }
}
