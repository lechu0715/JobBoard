using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.JobOffers
{
    public interface IJobOfferService
    {
        Task<List<JobOffer>> GetAllJobOffers();
        Task<JobOffer> GetJobOfferById(int id);
        Task AddJobOffer(JobOffer jobOffer);
        Task UpdateJobOffer(int id, JobOffer jobOffer);
        Task DeleteJobOffer(int id);
    }
}
