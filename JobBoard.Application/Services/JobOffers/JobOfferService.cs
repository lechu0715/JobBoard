using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Application.Services.JobOffers
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository)
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
