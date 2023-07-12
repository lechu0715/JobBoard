using ErrorOr;
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

    public class GetAllJobOffersQueryHandler : IRequestHandler<GetAllJobOffersQuery, ErrorOr<List<JobOffer>>>
    {
        private readonly IJobOfferQueryService _jobOfferQueryService;

        public GetAllJobOffersQueryHandler(IJobOfferQueryService jobOfferQueryService)
        {
            _jobOfferQueryService = jobOfferQueryService;
        }

        public async Task<ErrorOr<List<JobOffer>>> Handle(GetAllJobOffersQuery query, CancellationToken cancellationToken)
        {
            return await _jobOfferQueryService.GetAllJobOffers();
        }
    }
}
