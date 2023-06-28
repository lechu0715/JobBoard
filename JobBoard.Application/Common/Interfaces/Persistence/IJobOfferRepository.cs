using JobBoard.Domain.Entities;

namespace JobBoard.Application.Common.Interfaces.Persistence
{
    public interface IJobOfferRepository
    {
        Task<List<JobOffer>> GetAllJobOffers();
        Task<JobOffer> GetJobOfferById(int id);
        Task AddJobOffer(JobOffer jobOffer);
        Task UpdateJobOffer(int id, JobOffer jobOffer);
        Task DeleteJobOffer(int id);
    }
}
