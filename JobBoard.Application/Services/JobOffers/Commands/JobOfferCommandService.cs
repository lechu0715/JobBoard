using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.JobOffers
{
    public class JobOfferCommandService : IJobOfferCommandService
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferCommandService(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task AddJobOffer(JobOffer jobOffer)
        {
            await _jobOfferRepository.AddJobOffer(jobOffer);
        }

        public async Task UpdateJobOffer(int id, JobOffer jobOffer)
        {
            await _jobOfferRepository.UpdateJobOffer(id, jobOffer);
        }

        public async Task DeleteJobOffer(int id)
        {
            await _jobOfferRepository.DeleteJobOffer(id);
        }
    }
}
