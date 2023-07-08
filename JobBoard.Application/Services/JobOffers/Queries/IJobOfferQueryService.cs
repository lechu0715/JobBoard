using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.JobOffers
{
    public interface IJobOfferQueryService
    {
        Task<List<JobOffer>> GetAllJobOffers();
        Task<JobOffer> GetJobOfferById(int id);
    }
}
