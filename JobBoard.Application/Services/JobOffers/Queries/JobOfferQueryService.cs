using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.JobOffers
{
    public class JobOfferQueryService : IJobOfferQueryService
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferQueryService(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<List<JobOffer>> GetAllJobOffers()
        {
            return await _jobOfferRepository.GetAllJobOffers();
        }

        public async Task<JobOffer> GetJobOfferById(int id)
        {
            return await _jobOfferRepository.GetJobOfferById(id);
        }
    }
}
