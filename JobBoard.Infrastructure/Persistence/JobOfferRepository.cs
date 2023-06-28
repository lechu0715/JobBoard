using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;

namespace JobBoard.Infrastructure.Persistence
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private static readonly List<JobOffer> _jobOffers = new();

        public async Task<List<JobOffer>> GetAllJobOffers()
        {
            return _jobOffers;
        }

        public async Task<JobOffer> GetJobOfferById(int id)
        {
            return _jobOffers.SingleOrDefault(x => x.Id == id);
        }

        public async Task AddJobOffer(JobOffer jobOffer)
        {
            _jobOffers.Add(jobOffer);
        }

        public async Task UpdateJobOffer(int id, JobOffer jobOffer)
        {
            var existingJobOffer = _jobOffers.FirstOrDefault(x => x.Id == id);

            if (existingJobOffer == null)
            {
                return;
            }
            //todo
        }

        public async Task DeleteJobOffer(int id)
        {
            _jobOffers.Remove(_jobOffers.FirstOrDefault(x => x.Id == id));
        }
    }
}
